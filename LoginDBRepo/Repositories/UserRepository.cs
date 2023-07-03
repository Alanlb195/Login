using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoginDBRepo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LoginDBContext dbContext;
        public UserRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public async Task<Account?> GetUserById(int userId)
        {
            return await dbContext.Account.FirstOrDefaultAsync(u => u.IdAccount == userId);
        }

        public async Task<List<Account>> GetAllUsers()
        {
            return await dbContext.Account.ToListAsync();
        }

        public async Task AddUser (Account user)
        {
            dbContext.Account.Add(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser (Account user)
        {
            dbContext.Account.Update(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser (Account user)
        {
            dbContext.Account.Remove(user);
            await dbContext.SaveChangesAsync();
        }

    }
}