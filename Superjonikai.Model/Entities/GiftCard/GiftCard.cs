using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Superjonikai.Model.Entities.GiftCard
{
    public class GiftCard
    {
        public int Id { get; set; }
        public GiftCardType Type { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Message { get; set; }
        public double Price { get; set; }

        public GiftCard(int id, GiftCardType type, string message, double price)
        {
            Id = id;
            Type = type;
            Message = message;
            Price = price;
        }

        public GiftCard()
        {

        }
    }
}
