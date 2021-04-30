using Superjonikai.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Services
{
    class RegistrationService : IRegistrationService
    {
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
