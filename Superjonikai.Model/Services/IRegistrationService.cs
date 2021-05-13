using Superjonikai.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Services
{
    public interface IRegistrationService
    {
        ServerResult<User> Registration(Registration args);
        ServerResult<string> GetEmailFromToken(string token);


    }
}
