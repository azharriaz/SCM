using AutoMapper;
using SCM.StudentCourses.Services.Interfaces;
using SCM.StudentCourses.Entities;
using SCM.StudentCourses.ViewModels;
using SCM.StudentCourses.Repositories;
using SCM.StudentCourses.Repositories.Interfaces;

namespace SCM.StudentCourses.Services.Implementations
{
    public class CourseService:ServiceBase<CourseVM,Course>,ICourseService
    {
        public CourseService(ICourseRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
