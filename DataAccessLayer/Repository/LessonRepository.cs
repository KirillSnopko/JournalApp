using DataAccessLayer.Context;
using DataAccessLayer.Entity;


namespace DataAccessLayer.Repository
{
    public class LessonRepository : RepositoryBase<Lesson>
    {
        public LessonRepository(JournalContext context) : base(context)
        {
        }
    }
}
