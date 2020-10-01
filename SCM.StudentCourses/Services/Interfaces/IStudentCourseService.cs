using SCM.StudentCourses.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM.StudentCourses.Services.Interfaces
{
    public interface IStudentCourseService:IServiceBase<StudentCourseVM>
    {
       Task<IEnumerable<StudentCourseVM>> GetDetailsAsync();
       Task<IEnumerable<StudentCourseVM>> GetByRollNo(string rollNo);
       Task<bool> CheckWhetherCourseExistsAsync(int studentId, int courseId,int studentCourseId=0);
    }
}
