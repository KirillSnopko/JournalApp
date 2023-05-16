using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class GradeLevel
    {
        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public List<Topic> Topics { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
