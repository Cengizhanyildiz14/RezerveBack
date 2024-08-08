using Core;
using Entity;

namespace DataAccess.IDal
{
    public interface IUserDal : IRepository<User>
    {
        List<Role> GetClaims(User user);
        User GetByEmail(string email);
        IEnumerable<User> TumKullGetir();
        User GetUserWithAppointments(int userId);
        User GetByUsernameOrEmail(string username, string email);
    }
}
