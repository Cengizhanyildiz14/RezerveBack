using Core.Utilities.Results;
using Entity;

namespace Business.Interfaces
{
    public interface IAppointmentService
    {
        IResult CreateAppointment(Appointment appointment);
        IResult UpdateAppointment(int appointmentId, Appointment appointment);
        IResult DeleteAppointment(int appointmentId);
        IDataResult<Appointment> GetAppointmentById(int appointmentId);
        IDataResult<IEnumerable<Appointment>> GetAllAppointments();
        bool IsAppointmentAvailable(DateTime date, string time, int userId);
    }
}
