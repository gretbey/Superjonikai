﻿using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Entities;


namespace Superjonikai.Model.Repository
{
    public interface IUserRepository: IRepository<User>
    {
        User FindByToken(string token);
        List<User> GetAllByEmail(string email);
    }
}
