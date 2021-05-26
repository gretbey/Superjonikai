using Superjonikai.Model.DTO;


namespace Superjonikai.Model.IServices
{
    public interface IRegistrationService
    {
        ServerResult<User> Registration(Registration args);
        ServerResult<string> GetEmailFromToken(string token);


    }
}
