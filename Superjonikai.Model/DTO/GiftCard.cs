using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.DTO
{
    public class GiftCard
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public double Price { get; set; }
    }
}
