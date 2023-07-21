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
        private readonly RepositoryBase<Topic> repositoryTopic;
        public LessonService(RepositoryBase<Lesson> repository, IMapper mapper, RepositoryBase<Topic> repositoryTopic) : base(repository, mapper)
        {
            this.repositoryTopic = repositoryTopic;
        }

        public new LessonDto Add(LessonCreateDto create)
        {
            Lesson lesson = mapper.Map<Lesson>(create);
            List<Topic> topicList = lesson.Topics;
            lesson.Topics = new();
            lesson = repository.Create(lesson);
            repository.Save();
            lesson.Topics = topicList;

            topicList.ForEach(x => x.Lessons.Add(lesson));
            topicList.ForEach(x => repositoryTopic.Update(x));

            repository.Save();
            LessonDto dto = mapper.Map<LessonDto>(lesson);
            return dto;
        }

        public void Update(int id, LessonUpdateDto dto)
        {
            Lesson lesson = getByid(id);
            repository.Update(mapper.Map(dto, lesson));
            repository.Save();
        }

        public List<TopicDto> getAccessibleTopicsByLessonId(int id)
        {
            return getByid(id).Course.GradeLevel.Topics.Select(top => mapper.Map<TopicDto>(top)).ToList();
        }
    }
}
