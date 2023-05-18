using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto;

namespace LogicLayer.Service
{
    public class SubjectService : ServiceMain<Subject, SubjectDto, SubjectCreateDto>
    {
        public SubjectService(SubjectRepository subjectRepository, IMapper mapper) : base(subjectRepository, mapper) { }

        public override SubjectDto Add(SubjectCreateDto create)
        {
            if (create is null)
            {
                throw new ArgumentNullException(nameof(create), "subject is null");
            }
            if (string.IsNullOrWhiteSpace(create.Name))
            {
                throw new ArgumentException("Name of new subject is empty");
            }
            // repository.Create(mapper.Map<Subject>(create));
            //  repository.Save();
            Subject subject1 = repository.Create(mapper.Map<Subject>(create));
            repository.Save();
            SubjectDto subject = mapper.Map<SubjectDto>(subject1);
            return subject;
        }

        public override void Update(int id, SubjectCreateDto dto)
        {
            Subject subject = getByid(id);
            subject.Name = dto.Name;
            repository.Update(subject);
            repository.Save();
        }
    }
}
