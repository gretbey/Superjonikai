using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Services;
using Superjonikai.Model.DTO;

namespace Superjonikai.UI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("login")]
        public ServerResult<User> Login([FromBody] Login args)
        {
            return _loginService.Login(args);
        }
    }
}
