using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class StudentProfile : EntityBase
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int Level { get; set; }
        public string Description { get; set; } = String.Empty;
        public string StudentMobile { get; set; } = String.Empty;
        public string ParentName { get; set; } = String.Empty;
        public string ParentMobile { get; set; } = String.Empty;
        public virtual List<Course> Courses { get; set; } = new();
    }
}
