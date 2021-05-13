using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Superjonikai.Model.Entities
{
    public class Login
    {
        [Key, Required]
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; }
        public Login()
        {

        }

        public string Token { get; set; }

    }
}
