using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Context
{
    public class JournalContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GradeLevel> GradeLevel { get; set; }
        public DbSet<Topic> Topic { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfile { get; set; }

        public DbSet<Course> Course { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<LocalTopic> LocalTopic { get; set; }

        public DbSet<Log> Logs { get; set; }

        public JournalContext(DbContextOptions<JournalContext> options) : base(options) { }
    }
}
