using AskMe.DataAccessLayer.Abstract;
using AskMe.Entities.Model;
using AskMe.Interfaces;

namespace AskMe.Business
{
    public class QuestionManager : GenericManager<Question>, IQuestionService
    {
        private IQuestionRepository _questionRepository;

        public QuestionManager(IQuestionRepository questionRepository) : base(questionRepository)
        {

        }
    }
}
