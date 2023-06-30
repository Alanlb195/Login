using LoginDB.Models;
using LoginDBRepo.DBContext;
using LoginDBRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDBRepo.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly LoginDBContext _loginDBContext;

        public RolRepository(LoginDBContext loginDBContext)
        {
            _loginDBContext = loginDBContext;
        }

        public async Task<List<Rol>> GetAllRoles()
        {
            return await _loginDBContext.Rol.ToListAsync();
        }
    }
}
