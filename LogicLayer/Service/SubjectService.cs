using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.subject;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class SubjectService : ServiceMain<Subject, SubjectDto, SubjectCreateDto>
    {
        public SubjectService(RepositoryBase<Subject> subjectRepository, IMapper mapper) : base(subjectRepository, mapper) { }
    }
}
