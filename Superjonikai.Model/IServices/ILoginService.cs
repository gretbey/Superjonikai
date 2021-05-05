using Superjonikai.Model.Entities;

namespace Superjonikai.Model.Services
{
    public interface ILoginService
    {
        ServerResult<User> Login(Login args);
    }
}