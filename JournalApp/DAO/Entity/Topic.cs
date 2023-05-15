using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.DAO.Entity
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(GradeLevel))]
        public int GradeLevelId { get; set; }
        public GradeLevel GradeLevel { get; set; }
    }
}
