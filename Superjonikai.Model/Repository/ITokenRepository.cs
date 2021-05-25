using Superjonikai.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Repository
{
    public interface ITokenRepository : IRepository<Token>
    {
        Token FindByToken(string tokenString);
        List<Token> AllTokens(int userId);

    }
}
