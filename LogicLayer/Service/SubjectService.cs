using AutoMapper;
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

        public async Task<List<SubjectDto>> Get() => subjectRepository.GetAll().Result.Select(i => mapper.Map<SubjectDto>(i)).ToList();

        public async Task<SubjectDto> Get(int id)
        {
            try
            {
                return mapper.Map<SubjectDto>(subjectRepository.Get(id));
            }
            catch (InvalidOperationException ex)
            {
                throw new NotFoundException($"{ex.Message} => subject with id={id} not found");
            }
        }

        public async Task<SubjectDto> Create(SubjectCreateDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto), "subject is null");
            }
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Name of new subject is empty");
            }

            return mapper.Map<SubjectDto>(await subjectRepository.Add(mapper.Map<Subject>(dto)));
        }
    }
}
