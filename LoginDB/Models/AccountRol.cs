using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginDB.Models
{
    public class AccountRol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccountRol { get; set; }

        public int IdAccount { get; set; }
        [ForeignKey("IdAccount")]
        public Account Account { get; set; }

        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
    }
}
