using SCM.StudentResults.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentResults.Services.ExternalResources
{
    public interface IStudentCourseService
    {
        Task<IEnumerable<StudentCourseDTO>> GetStudentCoursesByRollNoAsync(string rollNo);
    }
}
