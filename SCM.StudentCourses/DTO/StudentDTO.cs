using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentCourses.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
    }
}
