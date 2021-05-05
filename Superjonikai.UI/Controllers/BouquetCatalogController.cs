using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using System.Collections.Generic;

namespace PSK.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BouquetCatalogController : ControllerBase
    {
        private readonly IBouquetsService _bouquetsService;

        public BouquetCatalogController(IBouquetsService bouquetsService)
        {
            _bouquetsService = bouquetsService;
        }

        [HttpGet]
        public ServerResult<List<Bouquet>> Bouquets()
        {
            return new ServerResult<List<Bouquet>>()
            {
                Success = true,
                Data = _bouquetsService.GetAll()
            };
        }

        [HttpGet("{id}")]
        public ServerResult<Bouquet> GetBouquet([FromRoute] int id)
        {
            return new ServerResult<Bouquet>()
            {
                Success = true,
                Data = _bouquetsService.Get(id)
            };
        }
    }
}