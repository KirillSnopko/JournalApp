using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.DAO.Entity
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }


        public Topic Topic { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public int PercentOfDecision { get; set; } = -1;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dddd, dd MMMM yyyy}")]
        public DateTime Date { get; set; }


        public bool IsCompleted { get; set; } = false;
        public bool isCanceled { get; set; } = false;
    }
}
