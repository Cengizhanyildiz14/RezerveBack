using Business.Interfaces;
using Core.Utilities.Results;
using DataAccess.IDal;
using Entity;

namespace Business.Concrete
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppoinmentDal _appointmentDal;

        public AppointmentService(IAppoinmentDal dal)
        {
            _appointmentDal = dal;
        }

        public IResult CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                return new ErrorResult("Appointment cannot be null");
            }

            if (!IsAppointmentAvailable(appointment.Date, appointment.Time, appointment.UserId))
            {
                return new ErrorResult("Aynı tarih ve saatte zaten bir randevu mevcut.");
            }

            _appointmentDal.Add(appointment);
            return new SuccessResult("Appointment created successfully.");
        }

        public IResult DeleteAppointment(int appointmentId)
        {
            var appointment = _appointmentDal.GetById(appointmentId);
            if (appointment != null)
            {
                _appointmentDal.Delete(appointment);
                return new SuccessResult("Appointment deleted successfully.");
            }
            else
            {
                return new ErrorResult("No appointment found with the given ID.");
            }
        }

        public IDataResult<IEnumerable<Appointment>> GetAllAppointments()
        {
            var appointments = _appointmentDal.GetAll();
            return new SuccessDataResult<IEnumerable<Appointment>>(appointments, "Appointments retrieved successfully.");
        }

        public IDataResult<Appointment> GetAppointmentById(int appointmentId)
        {
            if (appointmentId <= 0)
            {
                return new ErrorDataResult<Appointment>("Invalid appointment ID");
            }

            var appointment = _appointmentDal.Get(a => a.Id == appointmentId);
            if (appointment == null)
            {
                return new ErrorDataResult<Appointment>("No appointment found with the given ID.");
            }

            return new SuccessDataResult<Appointment>(appointment, "Appointment retrieved successfully.");
        }

        public bool IsAppointmentAvailable(DateTime date, string time, int userId)
        {
            return !_appointmentDal.GetAll().Any(a => a.UserId == userId && a.Date.Date == date.Date && a.Time == time);
        }

        public IResult UpdateAppointment(int appointmentId, Appointment appointment)
        {
            if (appointment == null)
            {
                return new ErrorResult("Appointment cannot be null");
            }
            if (appointmentId <= 0 || appointmentId != appointment.Id)
            {
                return new ErrorResult("Invalid appointment ID");
            }

            if (!IsAppointmentAvailable(appointment.Date, appointment.Time, appointment.UserId))
            {
                return new ErrorResult("Aynı tarih ve saatte zaten bir randevu mevcut.");
            }

            _appointmentDal.Update(appointment);
            return new SuccessResult("Appointment updated successfully.");
        }
    }
}
