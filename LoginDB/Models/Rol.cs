using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginDB.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }

        public virtual ICollection<ModuleRol> ModuleRols { get; set; }
    }
}
