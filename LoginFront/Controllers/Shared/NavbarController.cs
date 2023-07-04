using LoginDB.Models;
using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoginFront.Controllers.Shared
{

    public class NavbarController : Controller
    {

        private readonly IModuleService _moduleService;

        public NavbarController(
            IModuleService moduleService)
        {
            _moduleService = moduleService;

        }

        public async Task<IActionResult> Index()
        {
            var userDataCookie = HttpContext.Request.Cookies["UserData"];

            if (!string.IsNullOrEmpty(userDataCookie))
            {
                var userResponseJson = userDataCookie; // Assuming the cookie value is a JSON string
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);


                List<Module> modules = await _moduleService.GetModulesByUserAccess(userResponse.Token);

                ViewBag.Modules = modules;

                return PartialView("_Navbar");
            }


            return PartialView("_Navbar");
        }
    }


}
