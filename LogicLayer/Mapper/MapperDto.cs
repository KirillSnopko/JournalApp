using AutoMapper;
using DataAccessLayer.Entity;
using LogicLayer.Dto.course;
using LogicLayer.Dto.gradeLevel;
using LogicLayer.Dto.lesson;
using LogicLayer.Dto.log;
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
            CreateMap<Topic, TopicDto>().ReverseMap();
            CreateMap<LocalTopic, LocalTopicDto>().ReverseMap();


            CreateMap<Student, StudentDto>().ForMember(x => x.ProfileId, y => y.MapFrom(z => z.StudentProfile.Id));
            CreateMap<StudentCreateDto, Student>();

            CreateMap<ProfileCreateDto, StudentProfile>();
            CreateMap<StudentProfile, ProfileDto>()
                .ForMember(d => d.CountLesson, x => x.MapFrom(i => i.Courses.SelectMany(i => i.Lessons).Distinct().Count(i => i.IsCompleted)))
                .ForMember(d => d.CountUnpaid, x => x.MapFrom(i => i.Courses.SelectMany(i => i.Lessons).Distinct().Where(x => x.IsCompleted).Count(i => !i.IsPaid)));


            CreateMap<Course, CoursePreview>()
                .ForMember(d => d.Title, x => x.MapFrom(i => i.GradeLevel.Subject.Name + ", " + (i.GradeLevel.Description)))
                .ForMember(d => d.ExistUnpaid, x => x.MapFrom(i => i.Lessons.Where(x => x.IsCompleted).Any(y => !y.IsPaid)));
            CreateMap<CourseCreateByProfile, Course>();
            CreateMap<Course, CourseDto>()
                .ForMember(d => d.StudentName, x => x.MapFrom(i => i.StudentProfile.Student.Name))
                .ForMember(d => d.Title, x => x.MapFrom(i => i.GradeLevel.Subject.Name + ", " + (i.GradeLevel.Description)));
            CreateMap<CourseCreateDto, Course>();


            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonCreateDto, Lesson>()
             .ForMember(i => i.Topics, x => x.MapFrom(i => i.Topics.Select(top => new LocalTopic(top.Id, top.Title, top.Description)).ToList()));

            CreateMap<LessonUpdateDto, Lesson>()
             .ForMember(i => i.Topics, x => x.MapFrom(i => i.Topics.Select(top => new LocalTopic(top.Id, top.Title, top.Description)).ToList()));

            CreateMap<LogDto, Log>().ReverseMap();
            CreateMap<LogCreateDto, Log>().ReverseMap();
        }
    }
}
