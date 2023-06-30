using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginDBServices.Account.DTOs
{
    public class RegisterAccount
    {
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Nombre obligatorio")]
        public string Name { get; set; }


        [DisplayName("Lista de roles, selecciona uno o varios para el nuevo usuario")]
        [Required(ErrorMessage = "Selecciona almenos un rol")]
        public List<int> IdRoles { get; set; }

        [DisplayName("Usuario ya activado para ingresar, ¿O inactivo?")]
        [Required(ErrorMessage = "Selecciona si estará activo desde este momento o no")]
        public bool IsActive { get; set; }


        [DisplayName("Email")]
        [Required(ErrorMessage = "El Correo es Requerido")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; }


        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "La contraseña debe tener mínimo 8 caracteres, al menos una letra, un número y un carácter especial.")]
        public string Password { get; set; }

        [DisplayName("Confirmar contraseña")]
        [Required(ErrorMessage = "Confirma la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
