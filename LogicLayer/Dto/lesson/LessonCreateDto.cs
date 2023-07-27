
using LogicLayer.Dto.topic;

namespace LogicLayer.Dto.lesson
{
    public class LessonCreateDto
    {
        public int CourseId { get; set; }
        public List<TopicDto> Topics { get; set; } = new();
        public string Task { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public double Price { get; set; } = 0;
        public int LessonDuration { get; set; } = 0;
    }
}
