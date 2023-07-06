using LoginDB.Models;
using LoginDBServices.Interfaces;
using LoginDBServices.Models.DTOs;
using Newtonsoft.Json;

namespace LoginFront.Tools
{
    public class UserDataUtility
    {
        private readonly IModuleService _moduleService;

        public UserDataUtility(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public UserData GetUserData(string userDataCookie)
        {
            if (!string.IsNullOrEmpty(userDataCookie))
            {
                var userResponseJson = JsonConvert.DeserializeObject<UserResponse>(userDataCookie);
                var modules = _moduleService.GetModulesByUserAccess(userResponseJson.Token).GetAwaiter().GetResult();

                var userData = new UserData
                {
                    Modules = modules,
                    Token = userResponseJson.Token,
                    Name = userResponseJson.Name,
                    Email = userResponseJson.Email
                };

                return userData;
            }

            return null;
        }
    }
    public class UserData
    {
        public List<Module> Modules { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

