using AskMe.DataAccessLayer.Abstract;
using AskMe.Entities.Model;

namespace AskMe.DataAccessLayer.Concrete.EntityFramework.Repository
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        public EfUserRepository() : base()
        {

        }
    }
}
