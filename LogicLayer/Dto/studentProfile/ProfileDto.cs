using LogicLayer.Dto.student;

namespace LogicLayer.Dto.studentProfile
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public StudentDto Student { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string StudentMobile { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public List<CoursePreview> Courses { get; set; }

        public int CountLesson { get; set; }
        public int CountUnpaid { get; set; }
    }

    public class CoursePreview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool ExistUnpaid { get; set; }
    }
}
