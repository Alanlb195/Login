using System.ComponentModel.DataAnnotations;

namespace LoginDBServices.Models.DTOs
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
