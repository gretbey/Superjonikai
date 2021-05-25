using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using System;

namespace Superjonikai.Model.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository userRepository;

        public LoginService(IUserRepository userRepo)
        {
            userRepository = userRepo;
        }
        public ServerResult<User> Login(Login args)
        {
            try
            {
                if (args == null)
                    throw new Exception("Arguments are empty");

                Entities.User user = userRepository.GetByEmail(args.Email);
                if (user != null)
                    return new ServerResult<User>
                    {
                        Data = user.ToDTO(),
                        Success = true
                    };

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
    }
}
