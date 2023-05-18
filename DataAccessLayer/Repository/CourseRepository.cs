using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.iFace;

namespace DataAccessLayer.Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICrudRepository<Course>
    {
        public CourseRepository(JournalContext context) : base(context)
        {
        }
    }
}
