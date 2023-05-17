using DataAccessLayer.Context;
using DataAccessLayer.Entity;


namespace DataAccessLayer.Repository
{
    public class TopicRepository : RepositoryBase<Topic>
    {
        public TopicRepository(JournalContext context) : base(context)
        {
        }
    }
}
