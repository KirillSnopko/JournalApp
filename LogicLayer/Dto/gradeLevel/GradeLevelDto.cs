using DataAccessLayer.Entity;

namespace LogicLayer.Dto.gradeLevel
{
    public class GradeLevelDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
