using AutoMapper;
using DataAccessLayer.Entity;
using LogicLayer.Dto;

namespace LogicLayer.Mapper
{
    public class SubjectMapper:Profile
    {
        public SubjectMapper()
        {
            CreateMap<Subject, SubjectDto>();
        }
    }
}
