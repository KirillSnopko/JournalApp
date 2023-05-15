using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalApp.DAO.Entity
{
    public class GradeLevel
    {
        [Key]
        public int Id;
        public int Level;
        public string Description;
        public List<Topic> Topics;

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
