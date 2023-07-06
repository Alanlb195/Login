using LoginDB.Models;

namespace LoginDBRepo.Interfaces
{
    public interface IModuleRolRepository
    {
        Task AddModuleToRole(int idModule, int idRol);
        Task<List<ModuleRol>> GetIdModuleRolByIdRol(int idRol);
    }
}
