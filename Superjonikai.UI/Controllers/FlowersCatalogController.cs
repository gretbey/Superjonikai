using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Services;

namespace Superjonikai.UI.Controllers
{
    [Route("api/[controller]")]
    public class FlowersCatalogController : Controller
    {
        private readonly IFlowersCatalogService _flowersCatalogService;

        public FlowersCatalogController(IFlowersCatalogService flowersCatalogService)
        {
            _flowersCatalogService = flowersCatalogService;
        }

        //[HttpPost]
        //[Route("catalog")]
        //public ServerResult<User> Login([FromBody] Login args)
        //{
        //    return _loginService.Login(args);
        //}
    }
}
