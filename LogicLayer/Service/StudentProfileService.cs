using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.studentProfile;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class StudentProfileService : ServiceMain<StudentProfile, ProfileDto, ProfileCreateDto>
    {
        public StudentProfileService(RepositoryBase<StudentProfile> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
