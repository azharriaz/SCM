using SCM.StudentCourses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentCourses.Services.ExternalResources
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetStudentsAsync();
        Task<StudentDTO> GetStudentByRollNoAsync(string rollNo);
    }
}
