using Superjonikai.Model.DTO;

namespace Superjonikai.Model.IServices
{
    public interface ILoginService
    {
        ServerResult<User> Login(Login args);
        ServerResult<User> StartToken(string token);
        void Logout(string token);
    }
}