using System.ComponentModel.DataAnnotations;
namespace SCM.Students.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Name { get; set; }
        [MaxLength(20), Required]
        public string RollNo { get; set; }
        [MaxLength(70)]
        public string Email { get; set; }
        [MaxLength(15), Required]
        public string Phone { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
    }
}
