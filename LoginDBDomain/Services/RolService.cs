using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;

namespace LoginDBServices.Services
{

    public class RolService : IRolService
    {

        private readonly IRolRepository _rolRepository;
        private readonly IModuleRolRepository _moduleRolRepository;

        public RolService(IRolRepository rolRepository,
            IModuleRolRepository moduleRolRepository)
        {
            _rolRepository = rolRepository;
            _moduleRolRepository = moduleRolRepository;
        }


        public async Task addRole(RegisterRol registerRol)
        {
            //Añadimos el rol

            var rol = new Rol
            {
                isActive = registerRol.IsActive,
                Name = registerRol.Name,
            };

            await _rolRepository.AddRol(rol);

            //Añadimos todos los modulos para ese rol

            foreach (var idModule in registerRol.IdModule)
            {
                await _moduleRolRepository.AddModuleToRole(idModule, rol.IdRol);
            }

        }
    }
}
