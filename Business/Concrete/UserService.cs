using Business.Interfaces;
using DataAccess.IDal;
using Entity;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.GetByEmail(email);
        }

        public List<Role> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDal.TumKullGetir();
        }

        public User GetUserWithAppointments(int userId)
        {
            return _userDal.GetUserWithAppointments(userId);
        }
        public User GetByUsernameOrEmail(string username, string email)
        {
            return _userDal.GetByUsernameOrEmail(username, email);
        }
    }
}
