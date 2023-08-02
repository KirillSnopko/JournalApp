using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.lesson;
using LogicLayer.Dto.topic;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class LessonService : ServiceMain<Lesson, LessonDto, LessonCreateDto>
    {
        public LessonService(RepositoryBase<Lesson> repository, IMapper mapper) : base(repository, mapper) { }

        public void Update(int id, LessonUpdateDto dto)
        {
            repository.Update(mapper.Map<LessonUpdateDto, Lesson>(dto, getByid(id)));
            repository.Save();
        }

        public List<TopicDto> getAccessibleTopicsByLessonId(int id)
        {
            return getByid(id).Course.GradeLevel.Topics.Select(top => mapper.Map<TopicDto>(top)).ToList();
        }
    }
}
