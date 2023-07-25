using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.iFace;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DataAccessLayer.Repository
{
    public abstract class RepositoryBase<T> : ICrudRepository<T> where T : EntityBase
    {
        private JournalContext Context { get; set; }

        protected RepositoryBase(JournalContext context)
        {
            this.Context = context;
        }

        public T Create(T entity) => Context.Set<T>().Add(entity).Entity;

        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public List<T> FindAll() => Context.Set<T>().ToList();

        public List<T> FindByCondition(Expression<Func<T, bool>> expression) => Context.Set<T>().Where(expression).ToList();

        public T FindByIdFirst(int id) => Context.Set<T>().Single(i => i.Id == id);

        public void Update(T entity) => Context.Set<T>().Update(entity);

        public void Save() => Context.SaveChanges();
    }
}
