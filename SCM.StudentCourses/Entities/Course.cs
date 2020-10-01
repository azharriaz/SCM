using System.ComponentModel.DataAnnotations;
namespace SCM.StudentCourses.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string CourseNo { get; set; }
        public float CreditHours { get; set; }
    }
}
