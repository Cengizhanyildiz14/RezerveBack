using DataAccess.Contexts;
using DataAccess.IDal;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Dal
{
    public class UserDal : Repository<User, RezerveContext>, IUserDal
    {
        public List<Role> GetClaims(User user)
        {
            using (var context = new RezerveContext())
            {
                var result = context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == user.Id);
                return new List<Role> { result.Role };
            }
        }

        public User GetByEmail(string email)
        {
            using (var context = new RezerveContext())
            {
                return context.Users.FirstOrDefault(u => u.Email == email);
            }
        }

        public IEnumerable<User> TumKullGetir()
        {
            using (var context = new RezerveContext())
            {
                return context.Users.Include(u => u.Role).ToList();
            }
        }

        public User GetUserWithAppointments(int userId)
        {
            using (var context = new RezerveContext())
            {
                return context.Users
                              .Include(u => u.Appointments) // Kullanıcıya ait randevuları yükler
                              .FirstOrDefault(u => u.Id == userId);
            }
        }

        public User GetByUsernameOrEmail(string username, string email)
        {
            using (var context = new RezerveContext())
            {
                return context.Users.FirstOrDefault(u => u.UserName == username || u.Email == email);
            }
        }
    }
}
