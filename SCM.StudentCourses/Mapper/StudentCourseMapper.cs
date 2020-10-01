using AutoMapper;
using SCM.StudentCourses.Entities;
using SCM.StudentCourses.ViewModels;
namespace SCM.StudentCourses.Mapper
{
    public class StudentCourseMapper:Profile
    {
        public StudentCourseMapper()
        {
            CreateMap<StudentCourse, StudentCourseVM>()
                .ForMember(scvm => scvm.StudentCourseId, opt => opt.MapFrom(sce => sce.Id))
                .ForMember(scvm => scvm.CourseNo, opt => opt.MapFrom(sce => sce.Course.CourseNo))
                .ForMember(scvm => scvm.CourseName, opt => opt.MapFrom(sce => sce.Course.Name))
                .ForMember(scvm => scvm.TotalCreditHours, opt => opt.MapFrom(sce => sce.Course.CreditHours));
            CreateMap<StudentCourseVM, StudentCourse>()
                .ForMember(sce => sce.Course, opt => opt.Ignore())
                .ForMember(sce=>sce.Id,opt=>opt.MapFrom(scevm=>scevm.StudentCourseId));
        }
    }
}
