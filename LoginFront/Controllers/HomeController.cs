using login_12.Models;
using LoginDBServices.Account.DTOs;
using LoginDBServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace login_12.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Home
        [HttpGet]
        public IActionResult Index()
        {
            var userDataCookie = HttpContext.Request.Cookies["UserData"];

            if (!string.IsNullOrEmpty(userDataCookie))
            {
                var userResponseJson = userDataCookie; // Assuming the cookie value is a JSON string
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);

                ViewBag.Name = userResponse.Name;
                ViewBag.Email = userResponse.Email;
                ViewBag.Token = userResponse.Token;
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}