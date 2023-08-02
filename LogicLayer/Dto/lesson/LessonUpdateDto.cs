
using LogicLayer.Dto.topic;

namespace LogicLayer.Dto.lesson
{
    public class LessonUpdateDto
    {
        public int CourseId { get; set; }
        public List<TopicDto> Topics { get; set; } = new();
        public string Task { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public bool IsPaid { set; get; } = false;
        public double Price { get; set; } = 0;
        public DateTime DateOfPayment { get; set; }
        public int LessonDuration { get; set; } = 0;



        public bool IsPrepared { get; set; } = false;
        public bool IsTaskGiven { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public bool IsCanceled { get; set; } = false;


        public int GradeHome { get; set; } = 0;
        public int GradeLesson { get; set; } = 0;
    }
}
