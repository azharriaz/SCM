using SCM.StudentCourses.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM.StudentCourses.Repositories.Interfaces
{
    public interface IStudentCourseRepository:IGenericRepository<StudentCourse>
    {
        Task<IEnumerable<StudentCourse>> GetDetailAsync();
        Task<IEnumerable<StudentCourse>> GetByStudentIdAsync(int studentId);
    }
}
