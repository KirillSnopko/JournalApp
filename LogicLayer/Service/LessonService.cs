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
/*
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
        }*/

        public void Update(int id, LessonUpdateDto dto)
        {
            // Lesson old = getByid(id);
            //  Lesson young = mapper.Map<LessonUpdateDto, Lesson>(dto, old);
            //   List<Topic> topicList = young.Topics;
            //   young.Topics = new();
            // old = young;
            // repository.Update(old);

            Lesson t = mapper.Map<Lesson>(dto);
          /*  List<Topic> topics = dto.Topics.Select(i => mapper.Map<Topic>(i)).ToList();
            topics.ForEach(i => i.Lessons.Add(t));
            topics.ForEach(i => repositoryTopic.Update(i));
            repository.Save();*/

           
            t.Id = id;
            repository.Update(t);

            //  old.Topics = topicList;

            //  topicList.ForEach(x => x.Lessons.Add(old));
            //    topicList.ForEach(x => repositoryTopic.FindByIdFirst(x.Id).Lessons.Add(old));

           // repository.Save();




            //  List<Topic> removed = old.Topics.Except(listTopics).ToList();








            //     List<Topic> removed = old.Topics.Except(young.Topics).ToList();




            /*     removed.ForEach(x => old.Topics.Remove(x));
                 removed.ForEach(x => repositoryTopic.Update(x));
                 repository.Save();


                 List<Topic> added = young.Topics.Except(old.Topics).ToList();*/


            /*   added.ForEach(x => old.Topics.Add(x));
               added.ForEach(x => repositoryTopic.Update(x));
               repository.Save();

               old.Topics.AddRange(added);
               removed.ForEach(x => old.Topics.Remove(x));
               repository.Save();*/


            /*

                    old = young;
                       old.Topics = oldtopics;
                       repository.Update(old);
                       repository.Save();

                         repository.ClearTracker();
                          old = getByid(id);

                          removed.ForEach(x => old.Topics.Remove(x));
                          removed.ForEach(x => repositoryTopic.Update(x));

                          added.ForEach(x => old.Topics.Add(x));
                          added.ForEach(x => repositoryTopic.Update(x));
                          repository.Save();*/

        }

        public List<TopicDto> getAccessibleTopicsByLessonId(int id)
        {
            return getByid(id).Course.GradeLevel.Topics.Select(top => mapper.Map<TopicDto>(top)).ToList();
        }
    }
}
