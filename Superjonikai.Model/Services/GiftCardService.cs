using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;


namespace Superjonikai.Model.Services
{
    public class GiftCardService : IGiftCardService
    {
        private readonly IGiftCardRepository _giftCardRepo;

        public GiftCardService(IGiftCardRepository giftCardRepo)
        {
            _giftCardRepo = giftCardRepo;
        }

        public ServerResult<GiftCard> Get(int id)
        {
            Entities.GiftCard.GiftCard giftCard = _giftCardRepo.Get(id);
            return new ServerResult<GiftCard>
            {
                Data = giftCard.ToDTO(),
                Success = true
            };
        }

        public ServerResult<List<GiftCard>> GetAll()
        {
            var giftCards = _giftCardRepo.GetAll();
            return new ServerResult<List<GiftCard>>
            {
                Data = giftCards.Select(t => t.ToDTO()).ToList(),
                Success = true
            };
        }
    }
}
