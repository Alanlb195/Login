using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginDBServices.Models.DTOs
{
    public class RegisterAccountRequest
    {
        [DisplayName("Nombre")]
        [Required(ErrorMessage ="Nombre obligatorio")]
        public string Name { get; set; }


        [DisplayName("Lista de roles, selecciona uno para el nuevo usuario")]
        [Required(ErrorMessage = "Selecciona un rol")]
        public int IdRoles { get; set; }


        [DisplayName("Usuario Activado o Inactivo")]
        [Required(ErrorMessage = "Selecciona si estará activo desde este momento o no")]
        public bool IsActive { get; set; }


        [DisplayName("Email")]
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; }


        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "La contraseña debe tener mínimo 8 caracteres, al menos una letra, un número y un carácter especial.")]
        public string Password { get; set; }

        [DisplayName("Confirmar contraseña")]
        [Required(ErrorMessage ="Confirma la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}
