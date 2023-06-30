using LoginDBRepo.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using LoginDBServices.Account.DTOs;
using LoginDBServices.Account.Interfaces;
using LoginDBRepo.Interfaces;

namespace LoginDBServices.Account.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRolRepository _accountRolRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IGenerateWebTokenService _generateWebTokenService;


        public UserService(
            IOptions<AppSettings> appSettings,
            IConfiguration configuration,
            IAccountRepository accountRepository,
            IAccountRolRepository accountRolRepository,
            IRolRepository rolRepository,
            IGenerateWebTokenService generateWebToken)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _accountRepository = accountRepository;
            _accountRolRepository = accountRolRepository;
            _rolRepository = rolRepository;
            _generateWebTokenService = generateWebToken;
        }

        public async Task<UserResponse?> Auth(AuthRequest model)
        {
            using var db = new LoginDBContext();

            string hashedPassword = Encrypt.GetSHA256(model.Password);

            var account = await _accountRepository.GetAccountByEmailAndPassword(model.Email, model.Password);

            if (account == null)
                return null;

            // Obtengo todos los registros de la tabla Pivote que coinciden con el IdAccount de la cuenta
            var accountRoles = await _accountRolRepository.GetAccountRolesByAccountId(account.IdAccount);

            // Obtengo todos los roles
            var allRoles = await _rolRepository.GetAllRoles();

            // Filtro los roles para solo los que tenga el usuario


            foreach (var rolesDelUsuario in accountRoles)
            {

            }





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
