using LoginDB.Models;

namespace LoginDBRepo.Interfaces
{
    public interface IUserRepository
    {
        Task<Account?> GetUserById(int userId);
        Task<List<Account>> GetAllUsers();
        Task AddUser(Account user);
        Task UpdateUser(Account user);
        Task DeleteUser(Account user);
    }
}
