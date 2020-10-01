using AutoMapper;
using SCM.StudentCourses.ViewModels;
namespace SCM.StudentCourses.Mapper
{
    public class CourseMapper:Profile
    {
        public CourseMapper()
        {
            CreateMap<Entities.Course, CourseVM>()
                .ForMember(cvm => cvm.CourseId, opt => opt.MapFrom(ce => ce.Id)).ReverseMap();
        }
    }
}
