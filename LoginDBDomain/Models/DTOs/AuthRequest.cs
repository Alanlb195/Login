using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginDBServices.Models.DTOs
{
    public class AuthRequest
    {
        [DisplayName("Email")]
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
