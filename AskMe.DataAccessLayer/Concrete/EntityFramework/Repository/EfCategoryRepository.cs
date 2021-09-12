using AskMe.DataAccessLayer.Abstract;
using AskMe.Entities.Model;

namespace AskMe.DataAccessLayer.Concrete.EntityFramework.Repository
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository() : base()
        {

        }
    }
}
