using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;

namespace LoginDBRepo.Repositories
{
    public class RolModuleRepository : IRolModuleRepository
    {
        private readonly LoginDBContext dbContext;
        public RolModuleRepository(LoginDBContext loginDBContext)
        {
            dbContext = loginDBContext;
        }

        public void AssignModuleToRol(int moduleId, int rolId)
        {
            var rolModule = new RolModule
            {
                IdModule = moduleId,
                IdRol = rolId
            };
            dbContext.RolModule.Add(rolModule);
            dbContext.SaveChanges();
        }

        public void RemoveModuleFromRol(int moduleId, int rolId)
        {
            var rolModule = dbContext.RolModule.FirstOrDefault(rm => rm.IdModule == moduleId && rm.IdRol == rolId);
            if (rolModule != null)
            {
                dbContext.RolModule.Remove(rolModule);
                dbContext.SaveChanges();
            }
        }
    }
}
