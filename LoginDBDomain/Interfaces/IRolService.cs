using LoginDBServices.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDBServices.Interfaces
{
    public interface IRolService
    {
        Task addRole(RegisterRol registerRol);
    }
}
