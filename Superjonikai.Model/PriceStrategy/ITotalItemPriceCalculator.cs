using Superjonikai.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.PriceStrategy
{
    public interface ITotalItemPriceCalculator
    {
        public double CalculatePrice(Item item);
    }
}
