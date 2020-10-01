using AutoMapper;
using SCM.StudentCourses.Entities;
using SCM.StudentCourses.ViewModels;
using SCM.StudentCourses.Repositories.Interfaces;
using SCM.StudentCourses.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Net.Http;
using SCM.StudentCourses.DTO;
using Newtonsoft.Json;
using System.Linq;
using SCM.StudentCourses.Services.ExternalResources;
using System;

namespace SCM.StudentCourses.Services.Implementations
{
    public class StudentCourseService:ServiceBase<StudentCourseVM,StudentCourse>,IStudentCourseService
    {
        private readonly IStudentCourseRepository studentCourseRepository;
        private readonly IStudentService studentService;
        public StudentCourseService(IStudentCourseRepository repository, IMapper mapper,
            IStudentCourseRepository studentCourseRepository,
            IStudentService studentService) : base(repository, mapper)
        {
            this.studentCourseRepository = studentCourseRepository;
            this.studentService = studentService;
        }
        public async Task<bool> CheckWhetherCourseExistsAsync(int studentId, int courseId, int studentCourseId = 0)
        {
            if(studentCourseId>0)
            return (await this.studentCourseRepository.GetByExpression(m => m.StudentId == studentId 
            && m.CourseId == courseId && studentCourseId!=m.Id))?.Id>0;
            else return (await this.studentCourseRepository.GetByExpression(m => m.StudentId == studentId 
            && m.CourseId == courseId))?.Id > 0;
        }
        public async Task<IEnumerable<StudentCourseVM>> GetDetailsAsync()
        {
            // Load all Students from External Students MicroService.
            var students = await this.studentService.GetStudentsAsync();
            var studentCourseDetails = await this.studentCourseRepository.GetDetailAsync();
            // Here if Students Loaded are equels to null or service is down so we should return student courses detail.
            if (students == null) return this.Mapper.Map<IEnumerable<StudentCourseVM>>(studentCourseDetails);
            // IN case students are fetched successfully then map each studentCourse details with Student DTO's Name and Roll No.
            return this.mapStudents(students, this.Mapper.Map<IEnumerable<StudentCourseVM>>(studentCourseDetails));
        }
        
        // This function will map Student Details. StudentCourseVM's Student Name and Roll No properties will be mapped in this function
        private IEnumerable<StudentCourseVM> mapStudents(IEnumerable<StudentDTO> students,IEnumerable<StudentCourseVM> studentCourses)
        {
            if (students == null) return studentCourses;
            foreach (var item in studentCourses)
            {
                StudentDTO student = students.FirstOrDefault(student => student.StudentId == item.StudentId);
                if (student != null)
                {
                    item.RollNo = student.RollNo;
                    item.StudentName = student.Name;
                }
            }
            return studentCourses;
        }
        public async Task<float> CalculateCGPA(string rollno, string courseNo)
        {
            StudentDTO studentDTO = await this.studentService.GetStudentByRollNoAsync(rollno);
            // If Student Microservice is down due to any reason then we simply return 0 here.
            if (studentDTO == null) return 0F;
            var studentCourses =this.Mapper.Map<IEnumerable<StudentCourseVM>>(await this.studentCourseRepository.GetByStudentIdAsync(studentDTO.StudentId));
            return this.GetCGPA(studentCourses,courseNo);
        }
        
        private float GetCGPA(IEnumerable<StudentCourseVM> studentCourses, string courseNo)
        {
            if (studentCourses == null) 
                return 0F;
            // If course no is passed then simply return marks obtained otherwise returns cgpa.
            if (!string.IsNullOrEmpty(courseNo)) 
                return studentCourses.FirstOrDefault(m => m.CourseNo.Equals(courseNo)).ObtainedCreditHours;

            var activeCourses = studentCourses.Where(m => m.IsDeleted == false).Select(m => m.ObtainedCreditHours);
            if (activeCourses == null) return 0F;
            
            return float.Parse(string.Format("{0:0.00}", activeCourses.Sum()/activeCourses.Count()));
        }
    }
}
