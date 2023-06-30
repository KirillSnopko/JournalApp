


namespace DataAccessLayer.Entity
{
    public class Student : EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual StudentProfile StudentProfile { get; set; } = new StudentProfile();
    }
}