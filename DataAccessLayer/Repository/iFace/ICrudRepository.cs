

namespace DataAccessLayer.Repository.iFace
{
    public interface ICrudRepository<T>
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        T Get(int id);
        Task<List<T>> GetAll();
    }
}
