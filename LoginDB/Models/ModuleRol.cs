using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginDB.Models
{
    public class ModuleRol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdModuleRol { get; set; }

        public int IdModule { get; set; }
        [ForeignKey("IdModule")]
        public Module Module { get; set; }

        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
    }
}
