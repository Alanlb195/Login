using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBServices.Interfaces.Modules;

namespace LoginDBServices.Services.Modules
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<List<Module>> GetActiveModules()
        {
            var allModules = await _moduleRepository.GetAllModulesAsync();

            var activeModules = allModules.Where(a => a.IsActive == true).ToList();

            return activeModules;
        }





    }
}
