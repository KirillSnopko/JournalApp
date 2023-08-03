
namespace LogicLayer.Dto.lesson
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public List<LocalTopicDto> Topics { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public bool IsPaid { set; get; }
        public double Price { get; set; }
        public DateTime DateOfPayment { get; set; }
        public int LessonDuration { get; set; }



        public bool IsPrepared { get; set; }
        public bool IsTaskGiven { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }


        public int GradeHome { get; set; }
        public int GradeLesson { get; set; }
    }


    public class LocalTopicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
