using Superjonikai.DB;
using Superjonikai.Model.Entities.GiftCard;
using System;
using System.Collections.Generic;
using System.Linq;
using Superjonikai.Model.Repository;

namespace Superjonikai.DB.SQLRepository
{
    public class GiftCardSqlRepository : IGiftCardRepository
    {
        private readonly DBContext context;

        public GiftCardSqlRepository(DBContext context)
        {
            this.context = context;
        }
        public GiftCard Add(GiftCard giftCard)
        {
            context.GiftCards.Add(giftCard);
            context.SaveChanges();
            return giftCard;
        }

        public GiftCard Delete(int id)
        {
            GiftCard giftCard = context.GiftCards.Find(id);
            if (giftCard != null)
            {
                context.GiftCards.Remove(giftCard);
                context.SaveChanges();
            }
            return giftCard;
        }

        public GiftCard Get(int id)
        {
            return context.GiftCards.Find(id);
        }

        public List<GiftCard> GetAll()
        {
            return context.GiftCards.ToList<GiftCard>();
        }

        public GiftCard Update(GiftCard updatedGiftCard)
        {
            var giftCard = context.GiftCards.Attach(updatedGiftCard);
            giftCard.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedGiftCard;
        }
    }
}