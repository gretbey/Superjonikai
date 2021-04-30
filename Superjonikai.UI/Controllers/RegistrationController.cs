using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superjonikai.UI.Controllers
{
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

    }
}
