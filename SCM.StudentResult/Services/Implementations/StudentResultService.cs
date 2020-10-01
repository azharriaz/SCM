using Microsoft.AspNetCore.Mvc.ActionConstraints;
using SCM.StudentResults.DTO;
using SCM.StudentResults.Services.ExternalResources;
using SCM.StudentResults.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentResults.Services.Implementations
{
    public class StudentResultService:IStudentResultService
    {
        private readonly IStudentCourseService studentCourseService;
        public StudentResultService(IStudentCourseService studentCourseService)
        {
            this.studentCourseService = studentCourseService;
        }
        /// <summary>
        /// function calculates CGPA/GPA depending upon the parameters passed. External Service gets called to fetch student enrolled courses
        /// </summary>
        /// <param name="rollNo">roll No of student to fetch details</param>
        /// <param name="courseNo">if passed then GPA of course will be returned</param>
        /// <returns></returns>
        public async Task<float?> GetStudentCGPAAsync(string rollNo, string courseNo)
        {
            // Load all Students from External Students MicroService.
            var students = await this.studentCourseService.GetStudentCoursesByRollNoAsync(rollNo);

            // Load all Student Courses from local db.
            var studentCoursesDetail = await this.studentCourseService.GetStudentCoursesByRollNoAsync(rollNo);

            // Here if Students Loaded are equels to null or service is down so we return 0
            if (studentCoursesDetail == null)
                return
                    0;
            return
                this.CalculateCGPA(courseNo, studentCoursesDetail);
        }
        private float? CalculateCGPA(string courseNo,IEnumerable<StudentCourseDTO> studentCourses)
        {
            if (!String.IsNullOrEmpty(courseNo))
                return studentCourses.FirstOrDefault(m => m.CourseNo.Equals(courseNo))?.ObtainedCreditHours;
            
            var activeCourses = studentCourses.Where(m => m.IsDeleted == false).Select(m => m.ObtainedCreditHours);
            
            if (activeCourses == null)
                return 0;
            return 
                float.Parse(String.Format("{0:0.00}",activeCourses.Sum() / activeCourses.Count()));
        }
    }
}
