using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBRepo.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LoginDBRepo.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly LoginDBContext dbContext;

        public AccountRepository(LoginDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAccount(Account account)
        {
            dbContext.Account.Add(account);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Account> GetAccountByEmailAndPassword(string email, string password)
        {
            return await dbContext.Account.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }
    }
}
