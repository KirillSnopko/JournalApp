using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(StudentProfile))]
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }
        public Type Type { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dddd, dd MMMM yyyy}")]
        public DateTime DateOfStart { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public GradeLevel GradeLevel { get; set; }
        public List<Lesson> Lessons { get; set; }
    }

    public enum Type
    {
        Online, Offline
    }
}
