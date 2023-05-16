using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.iFace;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class SubjectRepository : ICrudRepository<Subject>
    {
        private readonly JournalContext context;

        public SubjectRepository(JournalContext applicationContext)
        {
            this.context = applicationContext;
        }

        public async Task<Subject> Add(Subject subject)
        {
            Subject newSubject = context.Subjects.Add(subject).Entity;
            context.SaveChangesAsync();
            return newSubject;
        }

        public void Update(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void Rename(int id, String name)
        {
            Subject subject = Get(id);
            subject.Name = name;
            context.SaveChanges();
        }

        public void Delete(Subject subject)
        {
            context.Subjects.Remove(subject);
            context.SaveChanges();
        }

        public Subject Get(int id)
        {
            return context.Subjects.Where(i => i.Id == id).First();
        }

        public async Task<List<Subject>> GetAll()
        {
            return await context.Subjects.ToListAsync();
        }
    }
}
