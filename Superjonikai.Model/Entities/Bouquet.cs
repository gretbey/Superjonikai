using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Entities
{
    public class Bouquet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        //photo
        public Bouquet()
        {

        }
        public Bouquet(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public Bouquet(int id, string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
