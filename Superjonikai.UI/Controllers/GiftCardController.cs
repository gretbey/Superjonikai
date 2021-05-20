using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using System.Collections.Generic;

namespace Superjonikai.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftCardController : ControllerBase
    {
        private readonly IGiftCardService _giftCardService;

        public GiftCardController(IGiftCardService giftCardService)
        {
            _giftCardService = giftCardService;
        }

        [HttpGet("/allGiftCards")]
        public ServerResult<List<GiftCard>> GiftCards()
        {
            return _giftCardService.GetAll();
        }

        [HttpGet("{id}")]
        public ServerResult<GiftCard> GetGiftCard([FromRoute] int id)
        {
            return _giftCardService.Get(id);
        }
    }
}
