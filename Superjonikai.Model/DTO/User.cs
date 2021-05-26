using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.DTO
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public DateTime EndTime { get; set; }
    }
}
