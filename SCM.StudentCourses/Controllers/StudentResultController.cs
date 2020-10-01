using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCM.StudentCourses.Services.Interfaces;

namespace SCM.StudentCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentResultController : ControllerBase
    {
        private readonly IStudentCourseService studentCourseService;
        public StudentResultController(IStudentCourseService studentCourseService)
        {
            this.studentCourseService = studentCourseService;
        }
        // GET: api/<StudentResultController>
        [HttpGet]
        public async Task<IActionResult> Get(string RollNo,string CourseNo)
        {
            try
            {
                if (String.IsNullOrEmpty(RollNo)) return BadRequest("Roll No of student is required for processing");
                return Ok(await this.studentCourseService.CalculateCGPA(RollNo, CourseNo));
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }
    }
}
