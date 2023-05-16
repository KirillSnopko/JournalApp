using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student student { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string StudentMobile { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}
