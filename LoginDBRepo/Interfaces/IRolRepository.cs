using LoginDB.Models;

namespace LoginDBRepo.Interfaces
{
    public interface IRolRepository
    {
        Rol GetRolById(int rolId);
        List<Rol> GetAllRoles();
        void AddRol(Rol rol);
        void UpdateRol(Rol rol);
        void DeleteRol(Rol rol);
    }
}
