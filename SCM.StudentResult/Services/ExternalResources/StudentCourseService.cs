using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SCM.StudentResults.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SCM.StudentResults.Services.ExternalResources
{
    public class StudentCourseService:IStudentCourseService
    {
        private readonly IConfiguration configuration;
        public StudentCourseService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// Fetches Students Courses from Student Course Service
        /// </summary>
        /// <param name="rollNo">Roll No against details are required</param>
        /// <param name="courseNo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StudentCourseDTO>> GetStudentCoursesByRollNoAsync(string rollNo)
        {
            try
            {
                IEnumerable<StudentCourseDTO> StudentCourseList;
                using var client = new HttpClient();
                var httpResponse = await client.GetAsync(this.GetStudentCourseUrl(rollNo));
                using (HttpContent content = httpResponse.Content)
                {
                    string json = await content.ReadAsStringAsync();
                    StudentCourseList = JsonConvert.DeserializeObject<IEnumerable<StudentCourseDTO>>(json);
                }
                return StudentCourseList;
            }
            catch (Exception)
            {
                return null;
            }
        }
       /// <summary>
       /// formates url for external resource
       /// </summary>
       /// <param name="rollNo"></param>
       /// <returns></returns>
        private string GetStudentCourseUrl(string rollNo)
        {
            return configuration["ExternalResources:StudentCourseBaseUrl"].ToString() + Common.StudentCourseUrl;
        }
    }
}
