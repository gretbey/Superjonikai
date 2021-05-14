using Superjonikai.Model.Entities;
using Superjonikai.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Services
{
    class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        public ServerResult<string> GetEmailFromToken(string token)
        {
            User user = _userRepository.FindByToken(token);

            if (user != null)
                return new ServerResult<string>
                {
                    Success = true,
                    Data = user.Email
                };

            else
                return new ServerResult<string>
                {
                    Success = false,
                    Message = "Token doesn't exist in the database"
                };
        }

        public ServerResult<User> Registration(Registration args)
        {
            try
            {
                if (args.Email =="user") //check if emails is valid, after db implementation 
                {
                    return new ServerResult<User>
                    {
                        Success = false,
                        Message = "Your email address is not valid.",
                        Data = null
                    };
                }
                else
                {
                    return new ServerResult<User>
                    {
                        Success = true,
                        Data = new User
                        {
                            Email = "user",
                            FirstName = "user",
                            LastName = "user",
                            PhoneNumber = "user"
                        },
                    };
                }
            }
            catch(Exception e)
            {
                return new ServerResult<User>
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
