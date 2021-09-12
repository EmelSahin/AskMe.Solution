using AskMe.DataAccessLayer.Abstract;
using AskMe.Entities.Model;
using AskMe.Interfaces;

namespace AskMe.Business
{
    public class UserManager : GenericManager<User>, IUserService
    {
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
