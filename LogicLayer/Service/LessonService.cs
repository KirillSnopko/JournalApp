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
            stat.CompletedCount = lessons.Count(i => i.IsCompleted);
            stat.PaidCount = lessons.Count(i => i.IsPaid);
            stat.TotalMoney = lessons.Where(i => i.IsPaid).Select(i => i.Price).Sum();

            return stat;
        }

        public LessonsMonthlyStatProfile MonthlyStat()
        {
            LessonsMonthlyStatProfile profileStat = new LessonsMonthlyStatProfile();
            List<Lesson> lessons = repository.FindAll();

            profileStat.LastCompleted = lessons.Where(i => i.IsCompleted).OrderBy(i => i.Date).Last().Date;
            profileStat.LastPaid = lessons.Where(i => i.IsPaid).OrderBy(i => i.DateOfPayment).Last().DateOfPayment;

            profileStat.Stat = lessons.GroupBy(i => i.Date.Year & i.Date.Month)
                 .Select(i => new LessonsMonthlyStat
                 {
                     Date = i.First().Date,
                     TotalCount = i.Count(x => x.IsCompleted),
                     TotalMoney = i.Where(x => x.IsPaid).Sum(x => x.Price)
                 })
                 .OrderBy(i => i.Date)
                 .ToList();

            return profileStat;
        }
    }
}
