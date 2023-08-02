using DataAccessLayer.Context;
using DataAccessLayer.Entity;


namespace DataAccessLayer.Repository
{
    public class LogRepository : RepositoryBase<Log>
    {
        public LogRepository(JournalContext context) : base(context)
        {
        }
    }
}
