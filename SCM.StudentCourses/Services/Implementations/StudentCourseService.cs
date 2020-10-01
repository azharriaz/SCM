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
        /// <summary>
        /// Check whether student is already enrolled for specified course
        /// </summary>
        /// <param name="studentId">student to be checked</param>
        /// <param name="courseId">course to be checked</param>
        /// <param name="studentCourseId">in case of edit let data to be upated</param>
        /// <returns></returns>
        public async Task<bool> CheckWhetherCourseExistsAsync(int studentId, int courseId, int studentCourseId = 0)
        {
            if(studentCourseId>0)
                return (await this.studentCourseRepository.GetByExpression(m => m.StudentId == studentId 
            && m.CourseId == courseId && studentCourseId!=m.Id))?.Id>0;
            else 
                return (await this.studentCourseRepository.GetByExpression(m => m.StudentId == studentId 
            && m.CourseId == courseId))?.Id > 0;
        }
        /// <summary>
        /// Load Details from External Student Service and map with local courses details to student details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentCourseVM>> GetDetailsAsync()
        {
            // Load all Students from External Students MicroService.
            var students = await this.studentService.GetStudentsAsync();
            
            // Load all Student Courses from local db.
            var studentCourseDetails = await this.studentCourseRepository.GetDetailAsync();
            
            // Here if Students Loaded are equels to null or service is down so we should return student courses detail.
            if (students == null) 
                return 
                    this.Mapper.Map<IEnumerable<StudentCourseVM>>(studentCourseDetails);
            
            // In case students are fetched successfully then map each studentCourse details with Student DTO's Name and Roll No.
            return 
                this.mapStudentDetails(students, this.Mapper.Map<IEnumerable<StudentCourseVM>>(studentCourseDetails));
        }
        /// <summary>
        /// Returns Student Courses by roll no.
        /// </summary>
        /// <param name="rollNo">Roll no of student</param>
        /// <returns></returns>
        public async Task<IEnumerable<StudentCourseVM>> GetByRollNo(string rollNo)
        {
            StudentDTO studentDTO = await this.studentService.GetStudentByRollNoAsync(rollNo);
            // If Student Microservice is down due to any reason then we simply return null here.
            if (studentDTO == null) 
                return null;
            else
                return 
                    this.Mapper.Map<IEnumerable<StudentCourseVM>>
                    (await this.studentCourseRepository.GetByStudentIdAsync(studentDTO.StudentId));
            
        }
        /// <summary>
        /// This function will map Student Details. StudentCourseVM's Student Name and Roll No properties will be mapped in this function
        /// </summary>
        /// <param name="students"></param>
        /// <param name="studentCourses"></param>
        /// <returns></returns>
        private IEnumerable<StudentCourseVM> mapStudentDetails(IEnumerable<StudentDTO> students,IEnumerable<StudentCourseVM> studentCourses)
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
    }
}
