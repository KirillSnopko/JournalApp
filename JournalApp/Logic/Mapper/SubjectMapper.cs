using AutoMapper;
using JournalApp.DAO.Entity;
using JournalApp.Logic.DTO;

namespace JournalApp.Logic.Mapper
{
    public class SubjectMapper:Profile
    {
        public SubjectMapper()
        {
            CreateMap<Subject, SubjectDto>();
        }
    }
}
