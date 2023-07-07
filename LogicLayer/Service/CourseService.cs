

using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using LogicLayer.Dto.course;
using LogicLayer.Service.Base;

namespace LogicLayer.Service
{
    public class CourseService : ServiceMain<Course, CourseDto, CourseCreateDto>
    {
        private readonly RepositoryBase<GradeLevel> gradeRepository;
        public CourseService(RepositoryBase<Course> repository, IMapper mapper, RepositoryBase<GradeLevel> gradeRepository) : base(repository, mapper)
        {
            this.gradeRepository = gradeRepository;
        }

        public CourseDto Add(CourseCreateByProfile dto)
        {
            GradeLevel grade = gradeRepository.FindByIdFirst(dto.GradelevelId);
            Course course = mapper.Map<Course>(dto);
            course.GradeLevel = grade;
            course = repository.Create(course);
            repository.Save();
            return mapper.Map<CourseDto>(course);
        }

    }
}
