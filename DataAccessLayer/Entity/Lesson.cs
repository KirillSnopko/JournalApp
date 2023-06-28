using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class Lesson : EntityBase
    {
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }


        public virtual Topic Topic { get; set; }
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
