using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Superjonikai.Model.Entities
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }

        public User()
        {

        }
        [Column(TypeName = "varchar(255)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Token { get; set; }
        public string endTime { get; set; }
    }
}
