using Superjonikai.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByToken(string token);
        List<User> GetAllByEmail(string email);
    }
}
