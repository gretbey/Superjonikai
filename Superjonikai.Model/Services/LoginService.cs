using Superjonikai.Model.Entities;
using Superjonikai.Model.IServices;
using System;

namespace Superjonikai.Model.Services
{
    public class LoginService : ILoginService
    {
        public ServerResult<User> Login(Login args)
        {
            try
            {
                if (args == null)
                    throw new Exception("Arguments are empty");

                if (args.Email == "user" && args.Password == "user")
                    return new ServerResult<User>
                    {
                        // Later it will change
                        Success = true,
                        Data = new User
                        {
                            Email = "user",
                            FirstName = "user",
                            LastName = "user"
                        },
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
