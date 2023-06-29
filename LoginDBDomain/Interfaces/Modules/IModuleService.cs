using LoginDB.Models;

namespace LoginDBServices.Interfaces.Modules
{
    public interface IModuleService
    {
        Task<List<Module>> GetActiveModules();

    }
}
