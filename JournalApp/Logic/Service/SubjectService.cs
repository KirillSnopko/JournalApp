using AutoMapper;
using JournalApp.DAO.Repository;
using JournalApp.Logic.DTO;
using JournalApp.Logic.Mapper;

namespace JournalApp.Logic.Service
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

        public async Task<List<SubjectDto>> Get() => await subjectRepository.GetAll().Result.Select(i => mapper.Map<SubjectDto>(i)).ToList();

    }
}
