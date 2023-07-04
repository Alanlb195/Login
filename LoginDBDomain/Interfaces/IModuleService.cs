using LoginDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDBServices.Interfaces
{
    public interface IModuleService
    {
        Task<List<Module>> GetModulesByUserAccess(string token);
    }
}
