using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using System;

namespace Superjonikai.Model.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository userRepository;
        private readonly ITokenRepository tokenRepository;

        public LoginService(IUserRepository userRepo, ITokenRepository tokenRepo)
        {
            userRepository = userRepo;
            tokenRepository = tokenRepo;
        }
        public ServerResult<User> Login(Login args)
        {
            try
            {
                if (args == null)
                    throw new Exception("Arguments are empty");

                Entities.User user = userRepository.GetByEmail(args.Email);
                if (user != null)
                {
                    tokenRepository.Add(new Entities.Token
                    {
                        User = user,
                        UserId = user.Id,
                        TokenString = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                        startTime = DateTime.Now,
                        endTime = DateTime.Now.AddHours(3)
                    });
                    return new ServerResult<User>
                    {
                        Data = user.ToDTO(),
                        Success = true
                    };
                }
                else
                    return new ServerResult<User>
                    {
                        Success = false,
                        Message = "Bad credentials",
                        Data = null,
                    };
            }
            catch (Exception e)
            {
                return new ServerResult<User>
                {
                    Success = false,
                    Message = e.Message,
                };
            }
        }

        public void Logout(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var currentToken = tokenRepository.FindByToken(token);
                if (currentToken != null && currentToken.endTime > DateTime.Now)
                {
                    currentToken.endTime = DateTime.Now;
                    tokenRepository.Update(currentToken);
                }
            }
        }

        public ServerResult<User> StartToken(string tokenString)
        {
            try
            {
                Entities.Token token = tokenRepository.FindByToken(tokenString);

                if (token.endTime < DateTime.Now)
                {
                    return new ServerResult<User>
                    {
                        Success = false,
                        Message = "Token has reached end time ",
                        Data = null,
                    };
                }

                return new ServerResult<User>
                {
                    Success = true,
                    Data = new User
                    {
                        Token = tokenString,
                        EndTime = token.endTime
                    },
                };
            }
            catch (Exception e)
            {
                return new ServerResult<User>
                {
                    Success = false,
                    Message = e.Message,
                };
            }
        }
       

    }
}
