

namespace DataAccessLayer.Repository.iFace
{
    public interface ICrudRepository<T>
    {
        Task<T> Add(T t);
        void Update(T t);
        void Delete(T t);
        T Get(int id);
        Task<List<T>> GetAll();
    }
}
