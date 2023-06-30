using AutoMapper;
using DataAccessLayer.Entity;
using LogicLayer.Dto.gradeLevel;
using LogicLayer.Dto.student;
using LogicLayer.Dto.studentProfile;
using LogicLayer.Dto.subject;
using LogicLayer.Dto.topic;

namespace LogicLayer.Mapper
{
    public class MapperDto : Profile
    {
        public MapperDto()
        {
            CreateMap<Subject, SubjectDto>().ForMember(d => d.Count, x => x.MapFrom(i => i.GradeLevels.Count));
            CreateMap<SubjectCreateDto, Subject>();

            CreateMap<GradeLevelCreateDto, GradeLevel>();
            CreateMap<GradeLevel, GradeLevelDto>().ForMember(d => d.Count, x => x.MapFrom(i => i.Topics.Count));

            CreateMap<TopicCreateDto, Topic>();
            CreateMap<Topic, TopicDto>();


            CreateMap<Student, StudentDto>();
            CreateMap<StudentCreateDto, Student>();

            CreateMap<ProfileCreateDto, StudentProfile>();
            CreateMap<StudentProfile, ProfileDto>();
            CreateMap<Course, CoursePreview>().ForMember(d => d.Title, x => x.MapFrom(i => i.GradeLevel.Subject.Name + ", " + (i.GradeLevel.Level)))
    .ForMember(d => d.ExistUnpaid, x => x.MapFrom(i => i.Lessons.Where(x => x.IsCompleted).Any(y => !y.IsPaid)));



        }
    }
}
