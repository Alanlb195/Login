namespace LoginDBRepo.Interfaces
{
    public interface IAccountRolRepository
    {
        Task AssignRolToAccount(int accountId, int rolId);
        Task RemoveRolFromAccount(int accountId, int rolId);
    }
}
