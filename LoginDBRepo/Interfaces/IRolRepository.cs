using LoginDB.Models;

namespace LoginDBRepo.Interfaces
{
    public interface IRolRepository
    {
        Task<Rol?> GetRolById(int rolId);
        Task<List<Rol>> GetAllRoles();
        Task AddRol(Rol rol);
        Task UpdateRol(Rol rol);
        Task DeleteRol(Rol rol);
    }
}
