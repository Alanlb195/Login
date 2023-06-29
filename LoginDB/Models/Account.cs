using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginDB.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccount { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<AccountRol> AccountsRoles { get; set; }
    }
}
