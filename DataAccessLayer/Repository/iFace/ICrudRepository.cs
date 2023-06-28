using System.Linq.Expressions;

namespace DataAccessLayer.Repository.iFace
{
    public interface ICrudRepository<T> 
    {
        List<T> FindAll();
        List<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T FindByIdFirst(int id);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
