using LoginDB.Models;
using LoginDBServices.Interfaces;

namespace LoginFront.Tools
{
    public class ModuleUtility
    {
        private readonly IModuleService _moduleService;

        public ModuleUtility(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public async Task<List<Module>> GetModulesByUserAccess(string token)
        {
            // Lógica para obtener los módulos utilizando el servicio de módulos
            return await _moduleService.GetModulesByUserAccess(token);
        }
    }

}
