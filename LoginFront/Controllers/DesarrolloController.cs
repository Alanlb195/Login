using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{
    //[Authorize(Roles = "DESARROLLO")]
    public class DesarrolloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
