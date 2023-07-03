using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace login_12.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(
            IUserService userService)
        {
            _userService = userService;
        }



        // GET: Login/Index
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            // Verificar si el usuario ya está autenticado
            if (User.Identity.IsAuthenticated)
            {
                // Redirigir a la página principal o a otra vista
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        // POST: Login/Auth
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Auth(AuthRequest authRequest)
        {
            if (!ModelState.IsValid)
                return View("Index", authRequest);
            
            // Si es válido llamar al userService que regresa un usuario response
            UserResponse? userResponse = await _userService.Auth(authRequest);

            // Verificar si el usuario existe
            if (userResponse == null)
            {
                ViewBag.Message = "Email o contraseña incorrectos";
                return View("Index", authRequest);
            }
            // Si el usuario existe: Serializar el UserResponse, guardar en una cookie
            var userResponseJson = JsonConvert.SerializeObject(userResponse);
            HttpContext.Response.Cookies.Append("UserData", userResponseJson);

            //  Se le redirecciona a Home junto con el token para su posterior validación
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Realiza las acciones necesarias para cerrar la sesión, como eliminar cookies, limpiar la información de autenticación, etc.
            HttpContext.Response.Cookies.Delete("UserData");

            return RedirectToAction("Index", "Login");
        }


    }
}
