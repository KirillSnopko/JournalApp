
namespace LogicLayer.Dto.lesson
{

    public class LessonsMonthlyStatProfile
    {
        public DateTime LastCompleted { get; set; }
        public DateTime LastPaid { get; set; }
        public List<LessonsMonthlyStat> Stat { get; set; } = new();

        public LessonsMonthlyStatProfile() { }
    }

    public class LessonsMonthlyStat
    {
        public DateTime Date { get; set; }
        public int TotalCount { get; set; }
        public double TotalMoney { get; set; }

        public LessonsMonthlyStat() { }
    }
}
