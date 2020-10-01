using AutoMapper;
using SCM.Students.Common;
using SCM.Students.Entities;
using SCM.Students.Repositories.Implementations;
using SCM.Students.Repositories.Interfaces;
using SCM.Students.Services.Interfaces;
using SCM.Students.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM.Students.Services.Implementations
{
    public class StudentService:ServiceBase<StudentVM, Student>,IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentService(IStudentRepository studentRepository,IMapper mapper):base(studentRepository, mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        public async Task<StudentVM> GetByRollNo(string rollno)
        {
            return this.mapper.Map<StudentVM>(await this.studentRepository.GetByRollNoAsync(rollno));
        }
    }
}
