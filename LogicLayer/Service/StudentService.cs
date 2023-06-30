
using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.student;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class StudentService : ServiceMain<Student, StudentDto, StudentCreateDto>
    {
        public StudentService(RepositoryBase<Student> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
