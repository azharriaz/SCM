using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCM.StudentCourses.Services.Interfaces;
using SCM.StudentCourses.ViewModels;

namespace SCM.StudentCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IStudentCourseService studentCourseService;

        public StudentCoursesController(IStudentCourseService studentCourseService)
        {
            this.studentCourseService = studentCourseService;
        }
        // GET: api/StudentCourses
        [HttpGet]
        public async Task<ActionResult<StudentCourseVM>> Get()
        {
            try
            {
                return Ok(await studentCourseService.GetDetailsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }
        // GET: api/StudentCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCourseVM>> Get(int id)
        {
            try
            {
                var studentCourse = await studentCourseService.GetByIdAsync(id);
                if (studentCourse == null)
                {
                    return NotFound();
                }
                return Ok(studentCourse);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }

        // PUT: api/StudentCourses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StudentCourseVM studentCourse)
        {
            try 
            {
                if (id != studentCourse.StudentCourseId || studentCourse == null) 
                    return BadRequest("Details are not appropriate");
                
                else if (await studentCourseService.CheckWhetherCourseExistsAsync(studentCourse.StudentId, studentCourse.CourseId, id))
                    return BadRequest("Student has already enrolled for selected course.");
                
                var studentCourseVM = await studentCourseService.UpdateAsync(studentCourse, id);
                
                if (studentCourseVM == null)
                    return BadRequest("Unable to update resourse");
                
                else return Ok(studentCourseVM);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }

        // POST: api/StudentCourses
        [HttpPost]
        public async Task<ActionResult<StudentCourseVM>> Post(StudentCourseVM studentCourse)
        {
            try
            {
                if (studentCourse == null)
                    return BadRequest("Details are not appropriate. Please try again with valid information");
               
                if (await studentCourseService.CheckWhetherCourseExistsAsync(studentCourse.StudentId, studentCourse.CourseId))
                    return BadRequest("Student has already enrolled for selected course.");
                
                var studentVM = await studentCourseService.AddAsync(studentCourse);
                
                return CreatedAtAction("Get", new { id = studentVM.StudentCourseId }, studentCourse);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
            
        }
        // DELETE: api/StudentCourses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                await studentCourseService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
            
        }
    }
}
