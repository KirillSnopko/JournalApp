using JournalApp.DAO.Entity;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.DAO.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
