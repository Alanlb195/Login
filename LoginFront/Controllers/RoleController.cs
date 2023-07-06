using LoginDB.Models;
using LoginDBRepo.Interfaces;
using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginFront.Controllers
{

    [Authorize(Roles = "ADMIN")]
    public class RoleController : Controller
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IRolService _rolService;

        public RoleController(
            IModuleRepository moduleRepository,
            IRolService rolservice)
        {
            _moduleRepository = moduleRepository;
            _rolService = rolservice;
        }



        // GET: RoleController
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            List<Module> modules = await _moduleRepository.GetAllModulesAsync();
            ViewBag.GeneralModules = modules;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRol request)
        {
            if (!ModelState.IsValid)
            {
                List<Module> modules = await _moduleRepository.GetAllModulesAsync();
                ViewBag.GeneralModules = modules;
                return View(request);
            }

            try
            {
                await _rolService.addRole(request);
                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                throw new Exception();
            }
        }






    }
}
