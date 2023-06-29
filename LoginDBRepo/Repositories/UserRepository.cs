using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;

namespace LoginDBRepo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LoginDBContext dbContext;
        public UserRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public Account GetUserById(int userId)
        {
            return dbContext.Account.FirstOrDefault(u => u.IdAccount == userId);
        }

        public List<Account> GetAllUsers()
        {
            return dbContext.Account.ToList();
        }

        public void AddUser (Account user)
        {
            dbContext.Account.Add(user);
            dbContext.SaveChanges();
        }

        public void UpdateUser (Account user)
        {
            dbContext.Account.Update(user);
            dbContext.SaveChanges();
        }

        public void DeleteUser (Account user)
        {
            dbContext.Account.Remove(user);
            dbContext.SaveChanges();
        }

    }
}
