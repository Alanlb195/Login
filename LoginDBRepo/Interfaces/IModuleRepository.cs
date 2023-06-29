using LoginDB.Models;

namespace LoginDBRepo.Interfaces
{
    public interface IModuleRepository
    {
        Task<Module?> GetModuleByIdAsync(int moduleId);
        Task<List<Module>> GetAllModulesAsync();
        Task AddModuleAsync(Module module);
        Task UpdateModuleAsync(Module module);
        Task DeleteModuleAsync(Module module);
    }
}
