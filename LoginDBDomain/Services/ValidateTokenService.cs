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

        /// <summary>
        /// Validate The Token, Return the Rol asociated at this user Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string ValidateToken(string token)
        {
            if (token == null)
                return null;

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
                var roleName = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;

                return roleName;
            }
            catch
            {
                return null;
            }
        }
    }
}
