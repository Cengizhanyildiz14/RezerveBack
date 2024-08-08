using Core.Jwt;
using Core.Utilities.Results;
using Dtos;
using Entity;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDto registerDto);
        IDataResult<User> Login(LoginDto loginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExist(RegisterDto registerDto);
    }
}
