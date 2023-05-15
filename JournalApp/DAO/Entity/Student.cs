using System.ComponentModel.DataAnnotations;

namespace JournalApp.DAO.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public StudentProfile StudentProfile { get; set; }
    }
}