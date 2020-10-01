using SCM.Students.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM.Students.Services.Interfaces
{
    public interface IStudentService:IServiceBase<StudentVM>
    {
        Task<StudentVM> GetByRollNo(string rollno);
        //Task<IEnumerable<StudentVM>> GetAllActiveStudents();
    }
}
