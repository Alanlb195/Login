using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{
    public class DesarrolloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
