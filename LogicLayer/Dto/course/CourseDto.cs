using LogicLayer.Dto.gradeLevel;
using LogicLayer.Dto.lesson;

namespace LogicLayer.Dto.course
{
    public class CourseDto
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public int StudentProfileId { get; set; }
        public string StudentName { get; set; }
        public string Type { get; set; }

        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }

        public double Price { get; set; }
        public int LessonDuration { get; set; }
        public string Description { get; set; }

        public GradeLevelDto GradeLevel { get; set; }
        public List<LessonDto> Lessons { get; set; }
    }
}
