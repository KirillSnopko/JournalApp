using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entity
{
    public class Topic : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(GradeLevel))]
        public int GradeLevelId { get; set; }
        public virtual GradeLevel GradeLevel { get; set; }

        public Topic() { }
        public Topic(int id, string title, string description, int gradeLevelId)
        {
            Id = id;
            Title = title;
            Description = description;
            GradeLevelId = gradeLevelId;
        }
    }
}
