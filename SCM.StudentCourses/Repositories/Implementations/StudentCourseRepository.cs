using Microsoft.EntityFrameworkCore;
using SCM.StudentCourses.Data;
using SCM.StudentCourses.Entities;
using SCM.StudentCourses.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentCourses.Repositories.Implementations
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(StudentCoursesDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<StudentCourse>> GetDetailAsync()
        {
            return await this.context.Set<StudentCourse>().Include(x => x.Course).ToListAsync();
        }
        public async Task<IEnumerable<StudentCourse>> GetByStudentIdAsync(int studentId)
        {
            return await this.context.Set<StudentCourse>().Where(m => m.StudentId == studentId).Include(x => x.Course).ToListAsync();
        }
    }
}