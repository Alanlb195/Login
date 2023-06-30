using LoginDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginDBRepo.Interfaces
{
    public interface IAccountRolRepository
    {
        Task AssignRolToAccount(int accountId, int rolId);
        Task RemoveRolFromAccount(int accountId, int rolId);
        Task<List<AccountRol>> GetAccountRolesByAccountId(int accountId);
        Task<List<AccountRol>> GetAccountRolesByRolId(int rolId);
    }
}