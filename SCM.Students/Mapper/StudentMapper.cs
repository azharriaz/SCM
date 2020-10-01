using AutoMapper;
using SCM.Students.Entities;
using SCM.Students.ViewModels;
namespace SCM.Students.Mapper
{
    public class StudentMapper:Profile
    {
        public StudentMapper()
        {
            CreateMap<Student, StudentVM>()
                .ForMember(svm => svm.StudentId, opt => opt.MapFrom(se => se.Id)).ReverseMap();
        }
    }
}
