using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentCourses.ViewModels
{
    public class CourseVM
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string CourseNo { get; set; }
        public float CreditHours { get; set; }
    }
}
