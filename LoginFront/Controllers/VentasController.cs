using LoginDB.Models;
using LoginDBServices.Interfaces;
using LoginFront.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{
    [Authorize(Roles = "VENTAS, ADMIN")]
    public class VentasController : Controller
    {
        private readonly IModuleService _moduleService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VentasController(
            IModuleService moduleService,
            IHttpContextAccessor httpContextAccessor)
        {
            _moduleService = moduleService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var isActivated = UserDataCookieHelper.IsThisModuleActivated(HttpContext, "VENTAS");

            if (isActivated == false)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            return View();
        }



    }
}
