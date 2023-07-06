using LogicLayer.Dto.gradeLevel;
using LogicLayer.Dto.lesson;

namespace LogicLayer.Dto.course
{
    internal class CourseDto
    {
        public int StudentProfileId { get; set; }
        public string Type { get; set; }

        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }

        public double Price { get; set; }
        public int LessonDuration { get; set; }
        public string Description { get; set; }

        public GradeLevelDto GradeLevel { get; set; }
        public virtual List<LessonDto> Lessons { get; set; }
    }
}
