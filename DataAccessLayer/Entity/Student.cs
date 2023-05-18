using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class Student : EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public StudentProfile StudentProfile { get; set; }
    }
}