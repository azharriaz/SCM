using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentCourses.ViewModels
{
    public class StudentCourseVM
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string RollNo { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseNo { get; set; }
        public float TotalCreditHours { get; set; }
        public float ObtainedCreditHours { get; set; }
        public bool IsDeleted { get; set; }
    }
}
