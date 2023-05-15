using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.DAO.Entity
{
    public class StudentProfile
    {
        [Key]
        [ForeignKey(nameof(Student))]
        public int Id { get; set; }
        public Student student;
        public int Level { get; set; }
        public string Description { get; set; }
        public string StudentMobile { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}
