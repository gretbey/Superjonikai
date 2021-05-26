using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.DTO
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Image_path { get; set; }
        public int Quantity { get; set;  }
        public string Size { get; set; }
        public double TotalPrice { get; set; }
    }
}
