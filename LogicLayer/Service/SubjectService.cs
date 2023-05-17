using AutoMapper;
using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto;
using LogicLayer.ServiceException;

namespace LogicLayer.Service
{
    public class SubjectService
    {
        private readonly SubjectRepository subjectRepository;
        private readonly IMapper mapper;

        public SubjectService(SubjectRepository subjectRepository, IMapper mapper)
        {
            this.subjectRepository = subjectRepository;
            this.mapper = mapper;
        }

        public List<SubjectDto> Get() => subjectRepository.FindAll().Select(i => mapper.Map<SubjectDto>(i)).ToList();

        public SubjectDto Get(int id) => mapper.Map<SubjectDto>(getSubjectById(id));

        public SubjectDto Create(SubjectCreateDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto), "subject is null");
            }
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Name of new subject is empty");
            }
            subjectRepository.Create(mapper.Map<Subject>(dto));
            subjectRepository.Save();
            Subject subject1 = subjectRepository.Create(mapper.Map<Subject>(dto));
            subjectRepository.Save();
            SubjectDto subject = mapper.Map<SubjectDto>(subject1);
            return subject;
        }

        public void Update(int id, SubjectCreateDto dto)
        {
            Subject subject = getSubjectById(id);
            subject.Name = dto.Name;
            subjectRepository.Update(subject);
            subjectRepository.Save();
        }

        public void Delete(int id)
        {
            subjectRepository.Delete(getSubjectById(id));
            subjectRepository.Save();
        }

        private Subject getSubjectById(int id)
        {
            try
            {
                return subjectRepository.FindByCondition(i => i.Id == id).First();
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException($"{ex.Message} => subject with id={id} not found");
            }
        }
    }
}
