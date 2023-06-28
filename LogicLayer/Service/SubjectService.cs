using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.gradeLevel;
using LogicLayer.Dto.subject;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class SubjectService : ServiceMain<Subject, SubjectDto, SubjectCreateDto>
    {
        public SubjectService(RepositoryBase<Subject> subjectRepository, IMapper mapper) : base(subjectRepository, mapper) { }

        public List<GradeLevelDto> getGradeLevel(int subjectid) => repository.FindByCondition(i => i.Id == subjectid)
            .First()
            .GradeLevels
            .Select(i => mapper.Map<GradeLevelDto>(i))
            .ToList();
    }
}
