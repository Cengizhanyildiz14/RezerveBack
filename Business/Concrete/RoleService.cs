using Business.Interfaces;
using DataAccess.IDal;
using Entity;

namespace Business.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleService(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Role GetById(int id)
        {
            return _roleDal.Get(id);
        }
    }
}

