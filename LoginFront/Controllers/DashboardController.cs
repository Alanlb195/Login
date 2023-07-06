using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace login_12.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRolRepository _rolRepository;
        public DashboardController(
            IUserService userService,
            IRolRepository rolRepository)
        {
            _userService = userService;
            _rolRepository = rolRepository;
        }


        // GET: Dashboard
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult RegisterRole()
        {
            return RedirectToAction("Index", "Roles");
        }




        // GET: Dashboard/Register
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            List<Rol> roles = await _rolRepository.GetAllRoles();
            ViewBag.Roles = roles;
            return View();
        }

        // POST: Dashboard/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountRequest request)
        {
            if (!ModelState.IsValid)
            {
                List<Rol> roles = await _rolRepository.GetAllRoles();
                ViewBag.Roles = roles;
                return View(request);
            }

            await _userService.AddNewUser(request);

            return View("Index", "Dashboard");

        }



    }
}