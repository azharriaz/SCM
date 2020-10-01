using Microsoft.EntityFrameworkCore;
using SCM.StudentCourses.Entities;

namespace SCM.StudentCourses.Data
{
    public class StudentCoursesDbContext : DbContext
    {
        public StudentCoursesDbContext(DbContextOptions<StudentCoursesDbContext> options): base(options)
        {
        }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse
                {
                    Id = 1,
                    StudentId=1,
                    CourseId = 1,
                    ObtainedCreditHours =3.0F,
                    IsDeleted = false
                },
                  new StudentCourse
                  {
                      Id = 2,
                      StudentId = 1,
                      CourseId = 2,
                      ObtainedCreditHours = 3.0F,
                      IsDeleted = false
                  },
                   new StudentCourse
                   {
                       Id = 3,
                       StudentId = 1,
                       CourseId = 3,
                       ObtainedCreditHours = 3.5F,
                       IsDeleted = false
                   },
                   new StudentCourse
                   {
                       Id = 4,
                       StudentId = 1,
                       CourseId = 4,
                       ObtainedCreditHours = 4.0F,
                       IsDeleted = false
                   },
                   new StudentCourse
                   {
                       Id = 5,
                       StudentId = 1,
                       CourseId = 5,
                       ObtainedCreditHours = 2.0F,
                       IsDeleted = false
                   },
                     new StudentCourse
                     {
                         Id = 6,
                         StudentId = 1,
                         CourseId = 6,
                         ObtainedCreditHours = 3.2F,
                         IsDeleted = false
                     }
            );
            modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Introduction to Computer Science - I", CourseNo = "BSCS-301", CreditHours = 3 },
            new Course { Id = 2, Name = "Mathematics - I (Calculus)", CourseNo = "BSCS-303", CreditHours = 4 },
            new Course { Id = 3, Name = "Statistics and Data Analysis", CourseNo = "BSCS-305", CreditHours = 3 },
            new Course { Id = 4, Name = "Physics - I (General Physics)", CourseNo = "BSCS-307", CreditHours = 3 },
            new Course { Id = 5, Name = "English", CourseNo = "BSCS-309", CreditHours = 3 },
            new Course { Id = 6, Name = "Islamic Learning & Pakistan Studies", CourseNo = "BSCS-311", CreditHours = 3 }
            );
        }
    }
}
