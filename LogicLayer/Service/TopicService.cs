using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.topic;
using LogicLayer.Service.Base;


namespace LogicLayer.Service
{
    public class TopicService : ServiceMain<Topic, TopicDto, TopicCreateDto>
    {
        public TopicService(RepositoryBase<Topic> topicRepository, IMapper mapper) : base(topicRepository, mapper) { }
    }
}
