using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginDBRepo.Repositories
{
    public class AccountRolRepository : IAccountRolRepository
    {
        private readonly LoginDBContext dbContext;

        public AccountRolRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public async Task<List<AccountRol>> GetAccountRolesByAccountId(int accountId)
        {
            return await dbContext.AccountRol.Where(ar => ar.IdAccount == accountId).ToListAsync();
        }
        public async Task<List<AccountRol>> GetAccountRolesByRolId(int rolId)
        {
            return await dbContext.AccountRol.Where(ar => ar.IdRol == rolId).ToListAsync();
        }

        public async Task AssignRolToAccount(int accountId, int rolId)
        {
            var accountRol = new AccountRol
            {
                IdAccount = accountId,
                IdRol = rolId
            };
            dbContext.AccountRol.Add(accountRol);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveRolFromAccount(int accountId, int rolId)
        {
            var accountRol = dbContext.AccountRol.FirstOrDefault(ar => ar.IdAccount == accountId && ar.IdRol == rolId);
            if (accountRol != null)
            {
                dbContext.AccountRol.Remove(accountRol);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
