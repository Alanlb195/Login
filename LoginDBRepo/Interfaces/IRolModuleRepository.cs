namespace LoginDBRepo.Interfaces
{
    public interface IRolModuleRepository
    {
        void AssignModuleToRol(int moduleId, int rolId);
        void RemoveModuleFromRol(int moduleId, int rolId);
    }
}
