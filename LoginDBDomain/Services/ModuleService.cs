using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBServices.Interfaces;

namespace LoginDBServices.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IValidateTokenService _validateTokenService;

        public ModuleService(
            IModuleRepository moduleRepository
,           IValidateTokenService validateTokenService)
        {
            _moduleRepository = moduleRepository;
            _validateTokenService = validateTokenService;
        }

        public async Task<List<Module>> GetModulesByUserAccess(string token)
        {

            //Obtener el rol o roles de la cuenta del usuario actual
            var tokenData = _validateTokenService.ValidateToken(token);







            var modules = await _moduleRepository.GetAllModulesAsync();

            ////filtrar solo los modulos del usuario
            //foreach (var module in modules)
            //{

            //}


            return modules;

        }
    }
}
