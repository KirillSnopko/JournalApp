using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class Subject : EntityBase
    {
        public string Name { get; set; }
        public List<GradeLevel> GradeLevels { get; set; } = new();
    }
}
