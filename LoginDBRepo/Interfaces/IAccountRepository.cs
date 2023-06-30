using LoginDB.Models;

namespace LoginDBRepo.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
        Task<Account> GetAccountByEmailAndPassword(string email, string password);
    }
}
