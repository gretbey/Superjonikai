using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model
{
    public static class EntityToDtoHelper
    {
        public static DTO.Bouquet ToDTO(this Entities.Bouquet bouquet)
        {
            return new DTO.Bouquet()
            {
                Id = bouquet.Id,
                Name = bouquet.Name,
                Price = bouquet.Price,
                Color = bouquet.Color,
                Image_path = bouquet.Image_path
            };
        }

        public static DTO.Flower ToDTO(this Entities.Flower flower)
        {
            return new DTO.Flower()
            {
                Id = flower.Id,
                Name = flower.Name,
                Price = flower.Price,
                Color = flower.Color,
                Image_path = flower.Image_path
            };
        }

        public static DTO.Order ToDTO(this Entities.Order.Order order)
        {
            return new DTO.Order()
            {
                Id = order.Id,
                ClientName = order.ClientName,
                DeliveryDate = order.DeliveryDate.Value.ToString("yyyy-MM-dd"),
                Status = order.Status.ToString(),
                RowVersion = order.RowVersion,
            };
        }

        public static DTO.GiftCard ToDTO(this Entities.GiftCard.GiftCard giftCard)
        {
            return new DTO.GiftCard()
            {
                Id = giftCard.Id,
                Message = giftCard.Message,
                Price = giftCard.Price,
                Type = giftCard.Type.ToString(),
            };
        }
    }
}
