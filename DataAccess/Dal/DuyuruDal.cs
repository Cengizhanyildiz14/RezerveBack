using DataAccess.Contexts;
using DataAccess.IDal;
using Entity;

namespace DataAccess.Dal
{
    public class DuyuruDal : Repository<Duyuru, RezerveContext>, IDuyuruDal
    {
    }
}
