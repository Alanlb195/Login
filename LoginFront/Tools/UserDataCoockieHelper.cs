using Newtonsoft.Json;
using LoginDBServices.Models.DTOs;

namespace LoginFront.Tools
{
    public static class UserDataCookieHelper
    {
        public static UserResponse GetUserDataFromCookie(HttpContext httpContext)
        {
            var serializedData = httpContext.Request.Cookies["UserData"];

            if (!string.IsNullOrEmpty(serializedData))
            {
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(serializedData);
                return userResponse;
            }

            return null;
        }

        public static List<ModuleResponse> GetActiveModulesFromCookie(HttpContext httpContext)
        {
            var userResponse = GetUserDataFromCookie(httpContext);

            if (userResponse != null)
            {
                var activeModules = userResponse.Modules.Where(module => module.IsActive).ToList();
                return activeModules;
            }

            return null;
        }

        // Ahora quiero que me regrese true o false dependiendo de si el modulo especificado está activo o no
        public static bool IsThisModuleActivated(HttpContext httpContext, string moduleName)
        {
            var activeModules = GetActiveModulesFromCookie(httpContext);

            if (activeModules != null)
            {
                return activeModules.Any(module => module.Name == moduleName);
            }

            return false;
        }


    }
}
