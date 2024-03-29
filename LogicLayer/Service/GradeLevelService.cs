﻿using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.gradeLevel;
using LogicLayer.Dto.topic;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class GradeLevelService : ServiceMain<GradeLevel, GradeLevelDto, GradeLevelCreateDto>
    {
        public GradeLevelService(RepositoryBase<GradeLevel> repository, IMapper mapper) : base(repository, mapper) { }

        public List<TopicDto> getTopics(int topicid) => repository.FindByCondition(i => i.Id == topicid)
           .First()
           .Topics
           .Select(i => mapper.Map<TopicDto>(i))
           .ToList();
    }
}
