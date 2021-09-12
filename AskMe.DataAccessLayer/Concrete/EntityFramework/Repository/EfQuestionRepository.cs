using AskMe.DataAccessLayer.Abstract;
using AskMe.Entities.Model;

namespace AskMe.DataAccessLayer.Concrete.EntityFramework.Repository
{
    public class EfQuestionRepository : EfGenericRepository<Question>, IQuestionRepository
    {
        public EfQuestionRepository() : base()
        {

        }
    }
}
