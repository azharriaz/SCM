using SCM.StudentCourses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SCM.StudentCourses.Services.ExternalResources
{
    public class StudentService:IStudentService
    {
        private readonly IConfiguration configuration;
        public StudentService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        ///  This function will read students from External Student Service which we will use later to map with StudentCourse Type.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentDTO>> GetStudentsAsync()
        {
            try
            {
                IEnumerable<StudentDTO> StudentList;
                using var client = new HttpClient();
                var httpResponse = await client.GetAsync(configuration["ExternalResources:StudentResource_BaseUrl"].ToString() + Common.StudentResoureUrl);
                using (HttpContent content = httpResponse.Content)
                {
                    string json = await content.ReadAsStringAsync();
                    StudentList = JsonConvert.DeserializeObject<IEnumerable<StudentDTO>>(json);
                }
                return StudentList;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        ///  This function takes rollNo of student and fetches student detail from External MicroService Resource
        /// </summary>
        /// <param name="rollNo"></param>
        /// <returns></returns>
        public async Task<StudentDTO> GetStudentByRollNoAsync(string rollNo)
        {
            try
            {
                StudentDTO Student;
                using var client = new HttpClient();
                var httpResponse = await client.GetAsync(configuration["ExternalResources:StudentResource_BaseUrl"].ToString() + Common.StudentResoureUrl + "/" + rollNo);
                using (HttpContent content = httpResponse.Content)
                {
                    string json = await content.ReadAsStringAsync();
                    Student = JsonConvert.DeserializeObject<StudentDTO>(json);
                }
                return Student;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
