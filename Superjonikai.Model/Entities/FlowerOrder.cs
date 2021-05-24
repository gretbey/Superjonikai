using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Entities.Order;

namespace Superjonikai.Model.Entities
{
    public class FlowerOrder
    {
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public virtual Order.Order Order { get; set; }

        public FlowerOrder()
        {

        }
    }
}
