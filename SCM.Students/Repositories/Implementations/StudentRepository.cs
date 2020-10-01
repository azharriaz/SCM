using Microsoft.EntityFrameworkCore;
using SCM.Students.Data;
using SCM.Students.Entities;
using SCM.Students.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Students.Repositories.Implementations
{
    public class StudentRepository:GenericRepository<Student>,IStudentRepository
    {
        public StudentRepository(StudentDbContext context) : base(context)
        {

        }
        public async Task<Student> GetByRollNoAsync(string rollNo)
        {
            return await this.context.Set<Student>().FirstOrDefaultAsync(m => m.RollNo.Equals(rollNo));
        }
    }
}
