using Superjonikai.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.PriceStrategy
{
    public class PriceCalculatorWithoutPVM: ITotalItemPriceCalculator
    {
        public double CalculatePrice(Item item)
        {
            double quantity = item.Quantity;
            double itemPrice = item.Price;
            double totalPricePerItem = Math.Round(quantity * itemPrice, 2);
            return totalPricePerItem;
        }
    }
}
