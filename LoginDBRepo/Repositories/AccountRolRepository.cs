// Tambien tengo una biblioteca de clases para manejar lógica directa hacia la base de datos.
using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoginDBRepo.Repositories
{
    public class AccountRolRepository : IAccountRolRepository
    {
        private readonly LoginDBContext dbContext;

        public AccountRolRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public async Task AssignRolToAccount(int accountId, int rolId)
        {
            var accountRol = new AccountRol
            {
                IdAccount = accountId,
                IdRol = rolId
            };
            await dbContext.AccountRol.AddAsync(accountRol);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveRolFromAccount(int accountId, int rolId)
        {
            var accountRol = await dbContext.AccountRol.FirstOrDefaultAsync(ar => ar.IdAccount == accountId && ar.IdRol == rolId);
            if (accountRol != null)
            {
                dbContext.AccountRol.Remove(accountRol);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
