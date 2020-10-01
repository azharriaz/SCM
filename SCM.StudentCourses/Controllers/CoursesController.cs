using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCM.StudentCourses.Services.Interfaces;
using SCM.StudentCourses.ViewModels;

namespace SCM.StudentCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        // GET: api/StudentCourses
        [HttpGet]
        public async Task<ActionResult<CourseVM>> GetStudentCourses()
        {
            try
            {
                return Ok(await courseService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong! Please try again"+ex.Message);
            }
            
        }
    }
}
