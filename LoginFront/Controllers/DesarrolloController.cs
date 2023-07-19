using LoginDB.Models;
using LoginDBServices.Interfaces;
using LoginFront.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{
    [Authorize(Roles = "DESARROLLO, ADMIN")]
    public class DesarrolloController : Controller
    {
        private readonly IModuleService _moduleService;

        public DesarrolloController(
            IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public async Task<IActionResult> Index()
        {
            var isActivated = UserDataCookieHelper.IsThisModuleActivated(HttpContext,"DESARROLLO");

            if (isActivated == false)
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            return View();
        }
    }
}
