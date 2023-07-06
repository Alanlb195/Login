using LoginDB.Models;
using LoginDBServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{
    public class DesarrolloController : Controller
    {
        private readonly IModuleService _moduleService;

        public DesarrolloController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [Authorize(Roles = "DESARROLLO, ADMIN")]
        public async Task<IActionResult> Index()
        {
            string token = ViewBag.Token;

            var modules = await _moduleService.GetModulesByUserAccess(token);

            if (modules != null)
            {
                var desarrolloModule = modules.FirstOrDefault(m => m.Name == "Desarrollo");

                if (desarrolloModule != null && !desarrolloModule.IsActive)
                {
                    return View();
                }
            }

            return RedirectToAction("Unauthorized", "Home");
        }
    }
}
