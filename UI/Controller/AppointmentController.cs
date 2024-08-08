using Business.Interfaces;
using Dtos;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("RandevuOlustur")]
        public IActionResult CreateAppointment([FromBody] AppointmentCreateDto appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointment = new Appointment
            {
                UserId = appointmentDTO.UserId,
                Date = appointmentDTO.Date,
                Time = appointmentDTO.Time,
                ActivityName = appointmentDTO.ActivityName,
                QRCodeUrl = appointmentDTO.QRCodeUrl
            };

            var result = _appointmentService.CreateAppointment(appointment);

            if (result.Success)
            {
                return Ok(result.Message); // Başarılı olursa, HTTP 200 (OK) yanıtı döner.
            }
            else
            {
                return BadRequest(result.Message); // Hata olursa, HTTP 400 (Bad Request) yanıtı döner.
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            try
            {
                _appointmentService.DeleteAppointment(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "data silinemedi");
            }

        }
    }
}