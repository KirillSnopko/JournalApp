
namespace LogicLayer.Dto.course
{
    public class CourseCreateByProfile
    {
        public int ProfileId { get; set; }
        public int SubjectId { get; set; }
        public int GradelevelId { get; set; }
        public string Type { get; set; }
    }
}

