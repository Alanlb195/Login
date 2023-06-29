using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;

namespace LoginDBRepo.Repositories
{
    public class AccountRolRepository : IAccountRolRepository
    {
        private readonly LoginDBContext dbContext;

        public AccountRolRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public void AssignRolToAccount(int accountId, int rolId)
        {
            var accountRol = new AccountRol
            {
                IdAccount = accountId,
                IdRol = rolId
            };
            dbContext.AccountRol.Add(accountRol);
            dbContext.SaveChanges();
        }

        public void RemoveRolFromAccount(int accountId, int rolId)
        {
            var accountRol = dbContext.AccountRol.FirstOrDefault(ar => ar.IdAccount == accountId && ar.IdRol == rolId);
            if (accountRol != null)
            {
                dbContext.AccountRol.Remove(accountRol);
                dbContext.SaveChanges();
            }
        }
    }
}
