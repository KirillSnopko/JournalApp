using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class GradeLevel : EntityBase
    {
        public int Level { get; set; }
        public string Description { get; set; }
        public List<Topic> Topics { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
