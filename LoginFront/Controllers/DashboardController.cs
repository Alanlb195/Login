using LoginDB.Models;
using LoginDBServices.Interfaces.Modules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace login_12.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class DashboardController : Controller
    {

        private readonly IModuleService _moduleService;
        public DashboardController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }


        // GET: Dashboard
        [HttpGet] public ActionResult Index()
        {
            return View();
        }
        
        
        
        
        // GET: Dashboard/Register
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var modules = await _moduleService.GetActiveModules();


            foreach (var module in modules)
            {
                // Crear un objeto que contenga la lista de módulos
                var model = new RegisterViewModel
                {
                    name = module.Name
                };
                return View(model);
            }

            return View();
        }




    }
}


public class RegisterViewModel
{
    public string name { get; set; }
}