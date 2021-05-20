using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Superjonikai.Model.Entities.Order
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string ClientName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
       
        [NotMapped]
        public virtual  ICollection<FlowerOrder> FlowersList { get; set; }
        [NotMapped]
        public virtual ICollection<BouquetOrder> BouquetsList { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Order()
        {

        }

        public Order(string clientName, DateTime deliveryDate, OrderStatus status)
        {
            ClientName = clientName;
            DeliveryDate = deliveryDate;
            Status = status;
        }

        public double CalculateTotalOrderPrice()
        {
            double totalSum = 0;

            if (FlowersList.Count > 0 || BouquetsList.Count > 0)
            {
                foreach (var flower in FlowersList)
                    totalSum += flower.Flower.Price;

                foreach (var boquet in BouquetsList)
                    totalSum += boquet.Bouquet.Price;
            }

            return totalSum;
        }
    }
}
