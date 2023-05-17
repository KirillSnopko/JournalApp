using DataAccessLayer.Context;
using DataAccessLayer.Entity;


namespace DataAccessLayer.Repository
{
    public class CourseRepository : RepositoryBase<Course>
    {
        public CourseRepository(JournalContext context) : base(context)
        {
        }
    }
}
