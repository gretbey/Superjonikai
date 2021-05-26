using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using System.Collections.Generic;
using Superjonikai.Model.ActionFilters;

namespace Superjonikai.UI.Controllers
{
    [LogActionFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class BouquetCatalogController : ControllerBase
    {
        private readonly IBouquetsService _bouquetsService;

        public BouquetCatalogController(IBouquetsService bouquetsService)
        {
            _bouquetsService = bouquetsService;
        }

        [HttpGet ("/allBouquets")]
        public ServerResult<List<Bouquet>> Bouquets()
        {
            return _bouquetsService.GetAll();
        }

        [HttpGet("/bouquets/{id}")]
        public ServerResult<Bouquet> GetBouquet([FromRoute] int id)
        {
            return _bouquetsService.Get(id);
        }

    }
}