using SCM.Students.Entities;
using SCM.Students.ViewModels;
using System.Threading.Tasks;

namespace SCM.Students.Repositories.Interfaces
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Task<Student> GetByRollNoAsync(string rollNo);
    }
}
