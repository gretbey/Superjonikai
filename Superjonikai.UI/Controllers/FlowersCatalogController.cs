﻿using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.DTO;
using Superjonikai.Model.Services;
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

        [HttpGet]
        public ServerResult<List<Flower>> Flowers()
        {
            return new ServerResult<List<Flower>>()
            {
                Success = true,
                Data = _flowersService.GetAll()
            };
        }

        [HttpGet("{id}")]
        public ServerResult<Bouquet> GetFlower([FromRoute] int id)
        {
            return new ServerResult<Bouquet>()
            {
                Success = true,
                Data = _flowersService.Get(id)
            };
        }
    }
}
