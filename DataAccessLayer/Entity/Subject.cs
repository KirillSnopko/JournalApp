
namespace DataAccessLayer.Entity
{
    public class Subject : EntityBase
    {
        public string Name { get; set; }
        public virtual List<GradeLevel> GradeLevels { get; set; } = new();
    }
}
