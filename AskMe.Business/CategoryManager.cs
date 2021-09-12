using AskMe.DataAccessLayer.Abstract;
using AskMe.Entities.Model;
using AskMe.Interfaces;

namespace AskMe.Business
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
