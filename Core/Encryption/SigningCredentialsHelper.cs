using Microsoft.IdentityModel.Tokens;

namespace Core.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSiginCredential(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
