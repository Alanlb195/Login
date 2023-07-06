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
        private readonly IRolRepository _rolRepository;
        private readonly IUserRepository _userRepository;

        public UserService(
            IOptions<AppSettings> appSettings,
            IConfiguration configuration,
            IGenerateWebTokenService generateWebToken,
            IRolRepository rolRepository,
            IUserRepository userRepository)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _generateWebTokenService = generateWebToken;
            _rolRepository = rolRepository;
            _userRepository = userRepository;
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

            var findRol = await _rolRepository.GetRolById(account.IdRol);

            if (findRol == null)
                return null;

            var userResponse = CreateUserResponse(account, findRol);

            return userResponse;
        }

        private UserResponse CreateUserResponse(Account account, Rol findRol)
        {
            return new UserResponse
            {
                Name = account.Name,
                Email = account.Email,
                Token = _generateWebTokenService.GenerateWebToken(account, findRol)
            };
        }



        /// <summary>
        /// Register a new user, Recibe a DTO, Validation of User and a Rol (IdRol)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddNewUser(RegisterAccountRequest request)
        {
            // Encriptar la contraseña
            string encryptedPassword = Encrypt.EncryptToSHA256(request.Password);

            // Buscar el rol para asignarlo al nuevo usuario
            var findRol = await _rolRepository.GetRolById(request.IdRol);

            if (findRol != null)
            {
                // Crear una nueva instancia de la clase Account y asignar el rol y el usuario
                var newUser = new Account
                {
                    Name = request.Name,
                    IsActive = request.IsActive,
                    Email = request.Email,
                    Password = encryptedPassword,
                    Rol = findRol
                };
                // Agregar el usuario a la base de datos
                await _userRepository.AddUser(newUser);
            }

        }



    }
}
