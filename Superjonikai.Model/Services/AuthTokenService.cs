using Superjonikai.Model.Entities;
using Superjonikai.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Services
{
    public interface IAuthTokenService
    {
        int Validate(string token);
    }
    public class AuthTokenService : IAuthTokenService
    {
        private readonly ITokenRepository tokenRepository;
        public AuthTokenService(ITokenRepository tokenRepo)
        {
            tokenRepository = tokenRepo;
        }
        public int Validate(string tokenString)
        {
            try
            {
                Token token = tokenRepository.FindByToken(tokenString);
                if (token == null) {
                    return -1;
                }

                int hasEnded = DateTime.Compare(token.endTime, DateTime.Now);
                return (hasEnded >= 1) ? token.UserId : -1;
            }
            
            catch
            {
                return -1;
            }
        }
    }
}
