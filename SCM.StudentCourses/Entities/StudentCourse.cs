using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SCM.StudentCourses.Entities
{
    public class StudentCourse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public float ObtainedCreditHours { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
