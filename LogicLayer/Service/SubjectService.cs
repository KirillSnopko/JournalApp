using AutoMapper;
using DataAccessLayer.Repository;
using LogicLayer.Dto;


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


    }
}
