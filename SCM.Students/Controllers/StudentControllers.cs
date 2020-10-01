using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCM.Students.Services.Interfaces;
using SCM.Students.ViewModels;

namespace SCM.Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        // GET: api/<Students>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentVM>>> Get()
        {
            try
            {
                return Ok(await studentService.GetAllAsync());
            }
            catch (Exception ex)
            { 
                return BadRequest("Something went wrong, please try again!"+ex.Message);
            }
            
        }

        // GET api/<Students>/5
        [HttpGet,Route("{id:int}")]
        public async Task<ActionResult<StudentVM>> Get(int id)
        {
            try
            {
                var student = await studentService.GetByIdAsync(id);
                if (student == null)
                {
                    return BadRequest("Student not found, please check Id and try again.!");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
            
        }
        // GET api/<Students>/5
        [HttpGet,Route("{rollNo}")]
        public async Task<ActionResult<StudentVM>> GetByRollNo(string rollNo)
        {
            try
            {
                var student = await studentService.GetByRollNo(rollNo);
                if (student == null)
                {
                    return BadRequest("Student not found, please check Roll No and try again.!");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
           
        }
        // POST api/<Students>
        [HttpPost]
        public async Task<ActionResult<StudentVM>> Post(StudentVM student)
        {
            try
            {
                var studentVM = await studentService.AddAsync(student);
                return CreatedAtAction("Get", new { id = studentVM.StudentId }, studentVM);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
            
        }
        // PUT: api/StudentCourses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StudentVM student)
        {
            try
            {
                if (id != student.StudentId)
                {
                    return BadRequest("Student Id is not valid, Please try with valid information.!");
                }
                var studentVM = await studentService.updateAsync(student, id);
                if (studentVM == null)
                    return NoContent();
                else return Ok(studentVM);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
            
        }
        // DELETE api/<Students>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteStudent(int id)
        {
            try
            {
                await studentService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }
    }
}
