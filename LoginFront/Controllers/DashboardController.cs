using LoginDB.Models;
using LoginDBServices.Account.DTOs;
using LoginDBServices.Interfaces.Modules;
using LoginDBServices.Interfaces.Roles;
using LoginDBServices.Services.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace login_12.Controllers
{
    //[Authorize(Roles = "ADMIN")]
    public class DashboardController : Controller
    {

        //private readonly IModuleService _moduleService;
        private readonly IRolService _roleService; 
        public DashboardController(
            IModuleService moduleService,
            IRolService roleService
            )
        {
            _roleService = roleService;
            //_moduleService = moduleService;
        }


        // GET: Dashboard
        [HttpGet] public ActionResult Index()
        {
            return View();
        }



        // GET: Register
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            List<Rol> activeRoles = await _roleService.GetAllActiveRoles();

            RegisterAccount model = new RegisterAccount();
            model.ActiveRoles = activeRoles;

            return View(model);
        }




    }
}


public class RegisterViewModel
{
    public string name { get; set; }
}