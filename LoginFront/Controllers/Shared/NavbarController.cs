using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers.Shared
{
    public class NavbarController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return PartialView("_Navbar");
        }
    }
}