using LoginDBServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginDBServices.Services
{
    public class ValidateTokenService : IValidateTokenService
    {
        private readonly IConfiguration _configuration;

        public ValidateTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Validate The Token
        public (string userName, string[] roles) ValidateToken(string token)
        {
            if (token == null)
                return (null, null);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtKey"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var jti = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Jti).Value;
                var userName = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
                var roles = jwtToken.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value).ToArray();

                return (userName, roles);
            }
            catch
            {
                return (null, null);
            }
        }
    }
}
