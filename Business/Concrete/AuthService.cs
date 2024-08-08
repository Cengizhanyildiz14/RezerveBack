using Business.Constants;
using Business.Interfaces;
using Core.Hashing;
using Core.Jwt;
using Core.Utilities.Results;
using Dtos;
using Entity;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly TokenHelper _tokenHelper;
        private readonly IRoleService _roleService;

        public AuthService(IUserService userService, TokenHelper tokenHelper, IRoleService roleService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _roleService = roleService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(LoginDto loginDto)
        {
            var checkUser = _userService.GetByEmail(loginDto.Email);
            if (checkUser == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, checkUser.PasswordHash, checkUser.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(checkUser, Messages.SuccessLogin);
        }

        public IDataResult<User> Register(RegisterDto registerDto)
        {
            byte[] passwordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out PasswordSalt);

            var role = _roleService.GetById(1);

            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                PasswordSalt = PasswordSalt,
                PasswordHash = passwordHash,
                Role = role,
                Gender = registerDto.Gender
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExist(RegisterDto registerDto)
        {
            bool userExists = _userService.GetByUsernameOrEmail(registerDto.UserName, registerDto.Email) != null;
            if (userExists)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
