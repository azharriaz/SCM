using Microsoft.EntityFrameworkCore;
using SCM.Students.Entities;

namespace SCM.Students.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Azhar Riaz",
                    RollNo = "RLNO-123",
                    Email="azhar@test.com",
                    Phone="+923416311582",
                    Address="Lahore, Pakistan",
                    IsDeleted=false  
                },
                 new Student
                 {
                     Id = 2,
                     Name = "Muzammil Ali",
                     RollNo = "RLNO-124",
                     Email = "muzammil@test.com",
                     Phone = "+923416313452",
                     Address = "Lahore, Pakistan",
                     IsDeleted = false
                 },
                 new Student
                 {
                     Id = 3,
                     Name = "Awais Ali",
                     RollNo = "RLNO-125",
                     Email = "awais234@test.com",
                     Phone = "+923416313098",
                     Address = "Bahawalpur, Pakistan",
                     IsDeleted = false
                 }, 
                 new Student
                 {
                     Id = 4,
                     Name = "Sheharyar Akram",
                     RollNo = "RLNO-126",
                     Email = "sheharyar04@test.com",
                     Phone = "+923416378798",
                     Address = "Qusoor, Pakistan",
                     IsDeleted = false
                 }
            );
        }
    }
}
