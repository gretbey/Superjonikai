using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Entities
{
    public class BouquetOrder
    {
        public int BouquetId { get; set; }
        public virtual Bouquet Bouquet { get; set; }
        public int OrderId { get; set; }
        public virtual Order.Order Order { get; set; }

        public BouquetOrder()
        {

        }
    }
}
