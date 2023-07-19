using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.lesson;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class LessonService : ServiceMain<Lesson, LessonDto, LessonCreateDto>
    {
        public LessonService(RepositoryBase<Lesson> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
