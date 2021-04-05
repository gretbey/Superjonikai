using Superjonikai.Model.Entities;
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

                if (args.Email == "admin" && args.Password == "admin")
                    return new ServerResult<User>
                    {
                        Success = true,
                        Data = new User
                        {
                            Email = "admin",
                            FirstName = "admin",
                            LastName = "admin"
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
