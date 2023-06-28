using AutoMapper;
using DataAccessLayer.Entity;
using LogicLayer.Dto.gradeLevel;


namespace LogicLayer.Mapper
{
    public class GradeLevelMapper : Profile
    {
        public GradeLevelMapper()
        {
            CreateMap<GradeLevelCreateDto, GradeLevel>();
            CreateMap<GradeLevel, GradeLevelDto>().ForMember(d => d.Count, x => x.MapFrom(i => i.Topics.Count));
        }
    }
}
