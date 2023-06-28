using AutoMapper;
using DataAccessLayer.Entity;
using LogicLayer.Dto.subject;

namespace LogicLayer.Mapper
{
    public class SubjectMapper:Profile
    {
        public SubjectMapper()
        {
            CreateMap<Subject, SubjectDto>().ForMember(d=>d.Count, x=>x.MapFrom(i=>i.GradeLevels.Count));
            CreateMap<SubjectCreateDto, Subject>();
        }
    }
}
