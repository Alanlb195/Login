using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoginDBRepo.Repositories
{
    public class ModuleRolRepository : IModuleRolRepository
    {
        private readonly LoginDBContext _loginDBContext;

        public ModuleRolRepository(LoginDBContext loginDBContext)
        {
            _loginDBContext = loginDBContext;
        }

        public async Task AddModuleToRole(int idModule, int idRol)
        {
            ModuleRol moduleRol = new ModuleRol
            {
                IdModule = idModule,
                IdRol = idRol
            };

            await _loginDBContext.ModuleRols.AddAsync(moduleRol);
            await _loginDBContext.SaveChangesAsync();
        }

        public async Task<List<ModuleRol>> GetIdModuleRolByIdRol(int idRol)
        {
            return await _loginDBContext.ModuleRols.Where(id => id.IdRol == idRol).ToListAsync();
        }
    }
}
