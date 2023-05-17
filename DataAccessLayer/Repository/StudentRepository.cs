using DataAccessLayer.Context;
using DataAccessLayer.Entity;


namespace DataAccessLayer.Repository
{
    public class StudentRepository : RepositoryBase<Student>
    {
        public StudentRepository(JournalContext context) : base(context) { }
    }
}
