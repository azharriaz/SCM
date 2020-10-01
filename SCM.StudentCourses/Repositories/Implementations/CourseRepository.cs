using SCM.StudentCourses.Data;
using SCM.StudentCourses.Entities;
using SCM.StudentCourses.Repositories.Interfaces;

namespace SCM.StudentCourses.Repositories.Implementations
{
    public class CourseRepository:GenericRepository<Course>,ICourseRepository
    {
        public CourseRepository(StudentCoursesDbContext dbContext):base(dbContext)
        {

        }
    }
}
