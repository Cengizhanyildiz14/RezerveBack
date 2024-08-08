using Entity;

namespace Business.Interfaces
{
    public interface IUserService
    {
        public List<Role> GetClaims(User user);
        void Add(User user);
        User GetByEmail(string email);
        public IEnumerable<User> GetAllUsers();
        User GetUserWithAppointments(int userId);
        User GetByUsernameOrEmail(string username, string email);
    }
}
