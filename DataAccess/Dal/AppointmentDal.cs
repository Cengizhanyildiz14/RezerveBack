using DataAccess.Contexts;
using DataAccess.IDal;
using Entity;

namespace DataAccess.Dal
{
    public class AppointmentDal : Repository<Appointment, RezerveContext>, IAppoinmentDal
    {
    }
}
