using DataAccess.Contexts;
using DataAccess.IDal;
using Entity;

namespace DataAccess.Dal
{
    public class RoleDal : Repository<Role, RezerveContext>, IRoleDal
    {
        public Role Get(int id)
        {
            using (var context = new RezerveContext())
            {
                return context.Roles.FirstOrDefault(r => r.Id == id);
            }
        }
    }
}
