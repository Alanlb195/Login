using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBServices.Interfaces;

namespace LoginDBServices.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IValidateTokenService _validateTokenService;
        private readonly IRolRepository _rolRepository;
        private readonly IModuleRolRepository _moduleRolRepository;

        public ModuleService(
            IModuleRepository moduleRepository
,           IValidateTokenService validateTokenService,
            IRolRepository rolRepository,
            IModuleRolRepository moduleRolRepository)
        {
            _moduleRepository = moduleRepository;
            _validateTokenService = validateTokenService;
            _rolRepository = rolRepository;
            _moduleRolRepository = moduleRolRepository;
        }

        /// <summary>
        /// Obtener los roles relacionados a un determinado Usuario, recibo el token de la coockie
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<List<Module>> GetModulesByUserAccess(string token)
        {
            List<Module> modules = new List<Module>();

            //Obtener el rol de la cuenta y validarlo
            var roleName = _validateTokenService.ValidateToken(token);


            if (roleName == null)
                return null;

            // Se seleccionan todos los roles
            var roles = await _rolRepository.GetAllRoles();

            // Se busca el rol entre la lista de todos los roles que coincida con el nombre del rol del token
            var rol = roles.Where(n => n.Name == roleName).FirstOrDefault();


            // Tabla Pivote, se seleccionan todos los ModuleRol que coincidan con el IdRol del token
            List<ModuleRol> ModuleRol = await _moduleRolRepository.GetIdModuleRolByIdRol(rol.IdRol);


            // Solo traera los modulos que estén activados
            foreach (var role in ModuleRol)
            {
                var moduleFound = await _moduleRepository.GetModuleByIdAsync(role.IdModule);

                if (moduleFound.IsActive)
                {
                    modules.Add(moduleFound);
                }
            }


            return modules;
        }
    }
}
