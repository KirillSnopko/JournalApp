using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.iFace;

namespace DataAccessLayer.Repository
{
    public class SubjectRepository : RepositoryBase<Subject>
    {
        public SubjectRepository(JournalContext applicationContext) : base(applicationContext) { }
    }
}
