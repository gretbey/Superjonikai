using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Entities;


namespace Superjonikai.Model.Repository
{
    public interface IUserRepository: IRepository<User>
    {
        User FindByToken(string token);
        User GetByEmail(string Email);
        List<User> GetAllByEmail(string email);
    }
}
