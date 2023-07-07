
namespace LogicLayer.Dto.course
{
    public class CourseCreateDto
    {
        public string Type { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }
        public double Price { get; set; }
        public int LessonDuration { get; set; }
        public string Description { get; set; }
        public int GradelevelId { get; set; }
    }
}
