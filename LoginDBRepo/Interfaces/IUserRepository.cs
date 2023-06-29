using LoginDB.Models;

namespace LoginDBRepo.Interfaces
{
    public interface IUserRepository
    {
        Account GetUserById(int userId);
        List<Account> GetAllUsers();
        void AddUser(Account user);
        void UpdateUser(Account user);
        void DeleteUser(Account user);
    }
}
