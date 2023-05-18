﻿using AutoMapper;
using DataAccessLayer.Entity;
using LogicLayer.Dto.subject;

namespace LogicLayer.Mapper
{
    public class SubjectMapper:Profile
    {
        public SubjectMapper()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectCreateDto, Subject>();
        }
    }
}
