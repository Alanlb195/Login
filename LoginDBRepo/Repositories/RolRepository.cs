using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoginDBRepo.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly LoginDBContext dbContext;
        public RolRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public async Task<Rol?> GetRolById(int rolId)
        {
            return await dbContext.Rol.FirstOrDefaultAsync(r => r.IdRol == rolId);
        }

        public async Task<List<Rol>> GetAllRoles()
        {
            return await dbContext.Rol.ToListAsync();
        }

        public async Task AddRol(Rol rol)
        {
            await dbContext.Rol.AddAsync(rol);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateRol(Rol rol)
        {
            dbContext.Rol.Update(rol);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRol(Rol rol)
        {
            dbContext.Rol.Remove(rol);
            await dbContext.SaveChangesAsync();
        }
    }
}
