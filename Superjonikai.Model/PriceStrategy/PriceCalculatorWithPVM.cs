using Superjonikai.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.PriceStrategy
{
    public class PriceCalculatorWithPVM: ITotalItemPriceCalculator
    {
        public double CalculatePrice(Item item)
        {
            double quantity = item.Quantity;
            double itemPrice = item.Price;
            double totalPricePerItem = quantity * itemPrice;
            double totalWithPVM = Math.Round(totalPricePerItem * 1.21, 2);
            return totalWithPVM;
        }
    }
}
