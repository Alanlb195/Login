using AutoMapper;
using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;

namespace LoginDBServices.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IValidateTokenService _validateTokenService;
        private readonly IRolRepository _rolRepository;
        private readonly IModuleRolRepository _moduleRolRepository;
        private readonly IMapper _mapper;

        public ModuleService(
            IModuleRepository moduleRepository
,           IValidateTokenService validateTokenService,
            IRolRepository rolRepository,
            IModuleRolRepository moduleRolRepository,
            IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _validateTokenService = validateTokenService;
            _rolRepository = rolRepository;
            _moduleRolRepository = moduleRolRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtener los roles relacionados a un determinado Usuario, recibo el token de la coockie
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<List<ModuleResponse>> GetModulesByUserAccess(string token)
        {
            List<ModuleResponse> modules = new List<ModuleResponse>();

            // Valida el token, regresa string rol.name
            var roleName = _validateTokenService.ValidateToken(token);


            if (roleName == null)
                return null;

            // Se seleccionan todos los roles
            var roles = await _rolRepository.GetAllRoles();

            // Se busca el rol entre la lista de todos los roles que coincida con el nombre del rol del token
            var rol = roles.Where(n => n.Name == roleName).FirstOrDefault();


            // Tabla Pivote, se seleccionan todos los ModuleRol que coincidan con el IdRol del token
            List<ModuleRol> ModuleRol = await _moduleRolRepository.GetIdModuleRolByIdRol(rol.IdRol);


            // Solo traera los modulos que estén activados, mapeo de objeto a un DTO
            foreach (var role in ModuleRol)
            {
                var moduleFound = await _moduleRepository.GetModuleByIdAsync(role.IdModule);

                if (moduleFound.IsActive)
                {
                    var moduleResponse = _mapper.Map<ModuleResponse>(moduleFound);
                    modules.Add(moduleResponse);
                }
            }
            return modules;
        }
    }
}
