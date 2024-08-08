using Core.Encryption;
using Core.Extension;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Jwt
{
    public class TokenHelper
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public TokenHelper(IConfiguration configuration)
        {
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<Role> role)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var sigingCredentials = SigningCredentialsHelper.CreateSiginCredential(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, sigingCredentials, role);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<Role> role)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(user, role),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<Role> role)
        {
            var claims = new List<Claim>();
            claims.AddName($"{user.UserName}");
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddRoles(role.Select(c => c.RoleName).ToArray());
            return claims;
        }
    }
}
