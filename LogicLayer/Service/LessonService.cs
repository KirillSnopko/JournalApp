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

        public LessonsStat Stat()
        {
            List<Lesson> lessons = repository.FindAll();
            LessonsStat stat = new LessonsStat();
            stat.TotalCount = lessons.Count;
            stat.CompletedCount = lessons.Where(i => i.IsCompleted).Count();
            stat.PaidCount = lessons.Where(i => i.IsPaid).Count();
            stat.TotalMoney = lessons.Where(i => i.IsPaid).Select(i => i.Price).Sum();

            return stat;
        }
    }
}
