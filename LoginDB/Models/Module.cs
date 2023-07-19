using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoginDB.Models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdModule { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection <ModuleRol> ModuleRols { get; set; }
    }
}
