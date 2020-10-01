using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.StudentResults.Services.Interfaces
{
    public interface IStudentResultService
    {
        Task<float?> GetStudentCGPAAsync(string rollNo, string courseNo);
    }
}
