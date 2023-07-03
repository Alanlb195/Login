using LoginDBRepo.DBContext;
using LoginDBServices.Models.Common;
using LoginDBServices.Models.DTOs;
using LoginDBServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using LoginDBRepo.Interfaces;
using LoginDB.Models;
using LoginDBServices.Tools;

namespace LoginDBServices.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        private readonly IGenerateWebTokenService _generateWebTokenService;
        private readonly IRolRepository _iRolRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRolRepository _accountRolRepository;

        public UserService(
            IOptions<AppSettings> appSettings,
            IConfiguration configuration,
            IGenerateWebTokenService generateWebToken,
            IRolRepository rolRepository,
            IUserRepository userRepository,
            IAccountRolRepository accountRolRepository)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _generateWebTokenService = generateWebToken;
            _iRolRepository = rolRepository;
            _userRepository = userRepository;
            _accountRolRepository = accountRolRepository;
        }

        /// <summary>
        /// Para obtener el JWT, recibe email y password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UserResponse?> Auth(AuthRequest model)
        {
            using var db = new LoginDBContext();

            string hashedPassword = EncryptionHelper.GetSHA256(model.Password);

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



        public async Task AddNewUser(RegisterAccountRequest request)
        {
            // Encriptar la contraseña
            string encryptedPassword = Encrypt.EncryptToSHA256(request.Password);


            // Crear una nueva instancia de la clase Account con los datos del DTO
            var newUser = new Account
            {
                Name = request.Name,
                IsActive = request.IsActive,
                Email = request.Email,
                Password = encryptedPassword
            };

            // Agregar el usuario a la base de datos
            await _userRepository.AddUser(newUser);

            // Asignar roles al usuario
            foreach (var roleId in request.IdRoles)
            {
                var rol = await _iRolRepository.GetRolById(roleId);

                if (rol != null)
                {
                    await _accountRolRepository.AssignRolToAccount(newUser.IdAccount, rol.IdRol);
                }
            }
        }



    }
}
