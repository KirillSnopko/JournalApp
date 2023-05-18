using DataAccessLayer.Entity;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository.iFace
{
    public interface ICrudRepository<T> 
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T FindByIdFirst(int id);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
