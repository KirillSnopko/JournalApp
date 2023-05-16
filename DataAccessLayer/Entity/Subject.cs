using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GradeLevel> GradeLevels { get; set; } = new();
    }
}
