using DataAccessLayer.Context;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository
{
    public class StudentProfileRepository : RepositoryBase<StudentProfile>
    {
        public StudentProfileRepository(JournalContext context) : base(context)
        {
        }
    }
}
