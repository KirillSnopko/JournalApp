using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class Topic : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(GradeLevel))]
        public int GradeLevelId { get; set; }
        public GradeLevel GradeLevel { get; set; }
    }
}
