using Business.Interfaces;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers().Select(u => new UserListDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                RoleId = u.RoleId,
                RoleName = u.Role?.RoleName
            });
            return Ok(users);
        }

        // Yeni metod
        [HttpGet("{id}")]
        public IActionResult GetUserWithAppointments(int id)
        {
            var user = _userService.GetUserWithAppointments(id);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var userDto = new UserDetailDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleName = user.Role?.RoleName,
                Gender = user.Gender,
                Appointments = user.Appointments.Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    Date = a.Date,
                    Time = a.Time,
                    ActivityName = a.ActivityName,
                    QRCodeUrl = a.QRCodeUrl,
                }).ToList()
            };

            return Ok(userDto);
        }
    }
}
