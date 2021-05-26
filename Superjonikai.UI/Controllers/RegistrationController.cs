using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.ActionFilters;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Services;

namespace Superjonikai.UI.Controllers
{
    [LogActionFilter]
    [Route("api/[controller]")]
    public class RegistrationController: Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("registration")]
        public ServerResult<User> Registration([FromBody] Registration args)
        {
            return _registrationService.Registration(args);
        }

        [HttpGet, Route("{token}")]
        public ServerResult<string> GetEmailFromToken(string token)
        {
            return _registrationService.GetEmailFromToken(token);
        }

    }
}
