using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;

namespace LoginDBRepo.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly LoginDBContext dbContext;
        public RolRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public Rol GetRolById(int rolId)
        {
            return dbContext.Rol.FirstOrDefault(r => r.IdRol == rolId);
        }

        public List<Rol> GetAllRoles()
        {
            return dbContext.Rol.ToList();
        }

        public void AddRol(Rol rol)
        {
            dbContext.Rol.Add(rol);
            dbContext.SaveChanges();
        }

        public void UpdateRol(Rol rol)
        {
            dbContext.Rol.Update(rol);
            dbContext.SaveChanges();
        }

        public void DeleteRol(Rol rol)
        {
            dbContext.Rol.Remove(rol);
            dbContext.SaveChanges();
        }
    }
}
