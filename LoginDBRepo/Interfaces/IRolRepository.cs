using LoginDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDBRepo.Interfaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAllRoles();
    }
}
