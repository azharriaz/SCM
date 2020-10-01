using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCM.StudentResults.Services.Interfaces;

namespace SCM.StudentResults.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentResultController : ControllerBase
    {
        private readonly IStudentResultService studentResultService;
        public StudentResultController(IStudentResultService studentResultService)
        {
            this.studentResultService = studentResultService;
        }
        // GET: api/<StudentResult>
        [HttpGet]
        public async Task<ActionResult<float?>> Get(string rollNo,string courseNo)
        {
            try
            {
                if (String.IsNullOrEmpty(rollNo))
                    return BadRequest("Roll No is required to calculate CGPA/GPA");
                return 
                    Ok(await studentResultService.GetStudentCGPAAsync(rollNo,courseNo));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong, please try again!" + ex.Message);
            }

        }
    }
}
