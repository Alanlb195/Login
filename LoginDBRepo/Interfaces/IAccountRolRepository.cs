namespace LoginDBRepo.Interfaces
{
    public interface IAccountRolRepository
    {
        void AssignRolToAccount(int accountId, int rolId);
        void RemoveRolFromAccount(int accountId, int rolId);
    }
}
