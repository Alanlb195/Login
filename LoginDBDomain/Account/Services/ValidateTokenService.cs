using LoginDBServices.Account.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LoginDBServices.Account.Services
{
    public class ValidateTokenService : IValidateTokenService
    {
        private readonly IConfiguration _configuration;

        public ValidateTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Validate The Token
        public string ValidateToken(string token)
        {
            if (token == null)
                return null;


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Convert.ToString(_configuration["JwtKey"]));

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
                var jti = jwtToken.Claims.First(claim => claim.Type == "jti").Value;
                var userName = jwtToken.Claims.First(sub => sub.Type == "sub").Value;

                return userName;
            }

            catch
            {
                return null;
            }
        }
    }
}
