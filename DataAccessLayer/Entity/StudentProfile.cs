using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class StudentProfile : EntityBase
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public virtual Student student { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string StudentMobile { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public virtual List<Course> Courses { get; set; } = new();
    }
}
