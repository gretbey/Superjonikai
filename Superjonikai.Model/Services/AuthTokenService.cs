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
        private readonly IUserRepository _userRepository;
        public AuthTokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Validate(string token)
        {
            try
            {
                User userToken = _userRepository.FindByToken(token);
                if (userToken == null)
                    return -1;

                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
