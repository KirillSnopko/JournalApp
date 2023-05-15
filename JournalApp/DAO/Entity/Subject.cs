using System.ComponentModel.DataAnnotations;

namespace JournalApp.DAO.Entity
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GradeLevel> GradeLevels { get; set; } = new();
    }
}
