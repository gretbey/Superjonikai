using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using System.Collections.Generic;

namespace Superjonikai.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowersCatalogController : ControllerBase
    {
        private readonly IFlowersCatalogService _flowersService;

        public FlowersCatalogController(IFlowersCatalogService flowersService)
        {
            _flowersService = flowersService;
        }

        [HttpGet("/allFlowers")]
        public ServerResult<List<Flower>> Flowers()
        {
            return _flowersService.GetAll();
        }

        [HttpGet("/flowers/{id}")]
        public ServerResult<Flower> GetFlower([FromRoute] int id)
        {
            return _flowersService.Get(id);
        }
    }
}
