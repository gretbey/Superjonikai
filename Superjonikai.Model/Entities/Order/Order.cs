using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Entities.Order
{
    class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<Flower> FlowersList { get; set; }
        public List<Bouquet> BouquetsList { get; set; }

        public Order(string clientName, DateTime deliveryDate, OrderStatus status )
        {
            ClientName = clientName;
            DeliveryDate = deliveryDate;
            Status = status;
        }

        public double CalculateTotalOrderPrice()
        {
            double totalSum = 0;

            if(FlowersList.Count > 0 || BouquetsList.Count > 0)
            {
                foreach(var flower in FlowersList)
                    totalSum += flower.Price;

                foreach (var boquet in BouquetsList)
                    totalSum += boquet.Price;
            }

            return totalSum;
        }

    }

}
