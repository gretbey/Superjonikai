using Superjonikai.Model.Entities;

namespace Superjonikai.Model.IServices
{
    public interface ILoginService
    {
        ServerResult<User> Login(Login args);
    }
}