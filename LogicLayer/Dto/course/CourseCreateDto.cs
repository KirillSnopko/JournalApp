
namespace LogicLayer.Dto.course
{
    public class CourseCreateDto
    {
        public string Type { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }
        public double Price { get; set; } = 0;
        public int LessonDuration { get; set; } = 0;
        public string Description { get; set; }= string.Empty;
        public int GradelevelId { get; set; }
    }
}
