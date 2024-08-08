using Core;
using Entity;

namespace DataAccess.IDal
{
    public interface IRoleDal : IRepository<Role>
    {
        Role Get(int id);
    }
}
