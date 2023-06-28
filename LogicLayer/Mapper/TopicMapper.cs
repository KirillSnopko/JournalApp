using AutoMapper;
using DataAccessLayer.Entity;
using LogicLayer.Dto.topic;


namespace LogicLayer.Mapper
{
    public class TopicMapper:Profile
    {
        public TopicMapper()
        {
            CreateMap<TopicCreateDto, Topic>();
            CreateMap<Topic, TopicDto>();
        }
    }
}
