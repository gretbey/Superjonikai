using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Repository;

namespace Superjonikai.DB.SQLRepository
{
    public class TokenSqlRepository: ITokenRepository
    {

        private readonly DBContext context;

        public TokenSqlRepository(DBContext context)
        {
            this.context = context;
        }
        public Token Add(Token token)
        {
            context.Tokens.Add(token);
            context.SaveChanges();
            return token;
        }

        public Token Delete(int id)
        {
            Token Token = context.Tokens.Find(id);
            if (Token != null)
            {
                context.Tokens.Remove(Token);
                context.SaveChanges();
            }
            return Token;
        }

        public Token Get(int id)
        {
            return context.Tokens.Find(id);
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Update(Token updatedToken)
        {
            var Token = context.Tokens.Attach(updatedToken);
            Token.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedToken;
        }

        public Token FindByToken(string token)
        {
            return context.Tokens.FirstOrDefault(Token => Token.Equals(token));
        }
        public List<Token> AllTokens(int userId)
        {
            return context.Tokens.Where(token => token.UserId == userId).ToList();
        }

        public List<Token> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
