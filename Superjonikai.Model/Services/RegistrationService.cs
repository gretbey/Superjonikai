using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using System;

namespace Superjonikai.Model.Services
{
    class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository userRepository;
        public RegistrationService(IUserRepository userRepo)
        {
            userRepository = userRepo;            
        }

        public ServerResult<string> GetEmailFromToken(string token)
        {
            throw new NotImplementedException();
        }

     
        public ServerResult<User> Registration(Registration args)
        {
            try
            {
                if (userRepository.GetByEmail(args.Email) != null)
                {
                    return new ServerResult<User>
                    {
                        Success = false,
                        Message = "this email already exists in the database"
                    };
                }
                var user = new Entities.User
                {
                    FirstName = args.FirstName,
                    LastName = args.LastName,
                    Email = args.Email,
                    PhoneNumber = args.PhoneNumber,
                    Token = args.Token,
                };
               
                userRepository.Add(user);

                return new ServerResult<User>
                { 
                    Data = user.ToDTO(),
                    Success = true
                };
            }
            catch (Exception e)
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
