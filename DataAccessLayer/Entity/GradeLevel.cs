using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class GradeLevel : EntityBase
    {
        public string Description { get; set; }
        public virtual List<Topic> Topics { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
