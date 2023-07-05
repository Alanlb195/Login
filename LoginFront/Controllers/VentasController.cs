using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{
    //[Authorize(Roles ="VENTAS")]
    public class VentasController : Controller
    {
        // GET: VentasController
        public ActionResult Index()
        {
            return View();
        }
    }



}
