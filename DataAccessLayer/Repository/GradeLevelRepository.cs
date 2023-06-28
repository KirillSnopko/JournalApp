using DataAccessLayer.Context;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository
{
    public class GradeLevelRepository : RepositoryBase<GradeLevel>
    {
        public GradeLevelRepository(JournalContext context) : base(context)
        {
        }
    }
}
