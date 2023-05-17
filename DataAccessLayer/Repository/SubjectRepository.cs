using DataAccessLayer.Context;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository
{
    public class SubjectRepository : RepositoryBase<Subject>
    {
        public SubjectRepository(JournalContext applicationContext) : base(applicationContext) { }
    }
}
