using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Context
{
    public class JournalContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }

        public JournalContext(DbContextOptions<JournalContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
