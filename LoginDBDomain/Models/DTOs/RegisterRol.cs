using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoginDBServices.Models.DTOs
{
    public class RegisterRol
    {
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es necesario")]
        public string Name { get; set; }

        [DisplayName("Rol Activo o Inactivo")]
        [Required(ErrorMessage = "The initial state is required")]
        public bool IsActive { get; set; }


        [DisplayName("Lista de Modulos, selecciona uno o varios para el nuevo Rol")]
        [Required(ErrorMessage = "Selecciona al menos un modulo")]
        public int[] IdModule { get; set; }
    }
}
