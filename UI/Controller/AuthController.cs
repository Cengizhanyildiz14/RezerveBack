using Business.Interfaces;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var userlogin = _authService.Login(loginDto);
            if (!userlogin.Success)
            {
                return BadRequest(userlogin.Message);
            }
            var result = _authService.CreateAccessToken(userlogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var userExist = _authService.UserExist(registerDto);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.Register(registerDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
