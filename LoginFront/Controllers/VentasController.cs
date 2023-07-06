using LoginDB.Models;
using LoginDBServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{
    public class VentasController : Controller
    {
        private readonly IModuleService _moduleService;

        public VentasController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [Authorize(Roles = "VENTAS, ADMIN")]
        public async Task<IActionResult> Index()
        {
            string token = ViewBag.Token;

            var modules = await _moduleService.GetModulesByUserAccess(token);

            if (modules != null)
            {
                var ventasModule = modules.FirstOrDefault(m => m.Name == "Ventas");

                if (ventasModule != null && !ventasModule.IsActive)
                {
                    return View();
                }
            }

            return RedirectToAction("Unauthorized", "Home");
        }
    }
}
