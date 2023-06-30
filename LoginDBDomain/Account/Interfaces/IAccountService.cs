using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoginDB.Models;
using System.Threading.Tasks;

namespace LoginDBServices.Account.Interfaces
{
    public interface IAccountService
    {
        public void AddAccount(Account account);
    }
}
