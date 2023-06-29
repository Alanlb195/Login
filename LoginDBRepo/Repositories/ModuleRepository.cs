using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoginDBRepo.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly LoginDBContext dbContext;

        public ModuleRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public async Task<Module?> GetModuleByIdAsync(int moduleId)
        {
            return await dbContext.Module.FirstOrDefaultAsync(m => m.IdModule == moduleId);
        }

        public async Task<List<Module>> GetAllModulesAsync()
        {
            return await dbContext.Module.ToListAsync();
        }

        public async Task AddModuleAsync(Module module)
        {
            await dbContext.Module.AddAsync(module);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateModuleAsync(Module module)
        {
            dbContext.Module.Update(module);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteModuleAsync(Module module)
        {
            dbContext.Module.Remove(module);
            await dbContext.SaveChangesAsync();
        }
    }
}
