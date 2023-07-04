namespace LoginDBRepo.Interfaces
{
    public interface IModuleRolRepository
    {
        Task AddModuleToRole(int idModule, int idRol);
    }
}
