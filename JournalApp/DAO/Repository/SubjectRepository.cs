using JournalApp.DAO.Context;
using JournalApp.DAO.Entity;
using JournalApp.DAO.Repository.iFace;
using Microsoft.EntityFrameworkCore;

namespace JournalApp.DAO.Repository
{
    public class SubjectRepository : ICrudRepository<Subject>
    {
        private readonly ApplicationContext applicationContext;

        public SubjectRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void Add(Subject subject)
        {
            applicationContext.Subjects.Add(subject);
            applicationContext.SaveChanges();
        }

        public void Update(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void Rename(int id, String name)
        {
            Subject subject = Get(id);
            subject.Name = name;
            applicationContext.SaveChanges();
        }

        public void Delete(Subject subject)
        {
            applicationContext.Subjects.Remove(subject);
            applicationContext.SaveChanges();
        }

        public Subject Get(int id)
        {
            return applicationContext.Subjects.Where(i => i.Id == id).First();
        }

        public async Task<List<Subject>> GetAll()
        {
            return await applicationContext.Subjects.ToListAsync();
        }
    }
}
