using LoginDBRepo.DBContext;
using LoginDBServices.Models.Common;
using LoginDBServices.Models.DTOs;
using LoginDBServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginDBServices.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        private readonly IGenerateWebTokenService _generateWebTokenService;

        public UserService(IOptions<AppSettings> appSettings, IConfiguration configuration, IGenerateWebTokenService generateWebToken)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _generateWebTokenService = generateWebToken;
        }

        public async Task<UserResponse?> Auth(AuthRequest model)
        {
            using var db = new LoginDBContext();

            string hashedPassword = Encrypt.GetSHA256(model.Password);

            var account = await db.Account
                .FirstOrDefaultAsync(d => d.Email == model.Email && d.Password == hashedPassword);

            if (account == null)
                return null;

            var accountRoleIds = await db.AccountRol
                .Where(a => a.IdAccount == account.IdAccount)
                .Select(a => a.IdRol)
                .ToListAsync();

            var roleNames = await db.Rol
                .Where(r => accountRoleIds.Contains(r.IdRol))
                .Select(r => r.Name)
                .ToListAsync();

            var userResponse = new UserResponse
            {
                Name = account.Name,
                Email = account.Email,
                Token = _generateWebTokenService.GenerateWebToken(account, roleNames)
            };

            return userResponse;
        }
    }
}
