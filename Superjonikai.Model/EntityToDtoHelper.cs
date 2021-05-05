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
            };
        }

        public static DTO.Flower ToDTO(this Entities.Flower flower)
        {
            return new DTO.Flower()
            {
                Id = flower.Id,
                Name = flower.Name,
                Price = flower.Price,
            };
        }
    }
}
