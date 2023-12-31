﻿using LoginDB.Models;

namespace LoginDBServices.Models.DTOs
{
    [Serializable]
    public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<ModuleResponse> Modules { get; set; }
    }
}
