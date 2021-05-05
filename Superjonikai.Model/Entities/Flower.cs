using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.Entities
{
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        //photo

        public Flower()
        {

        }

        public Flower (string name, double price, string color)
        {
            Name = name;
            Price = price;
            Color = color;
        }

        public Flower(int id, string name, double price, string color)
        {
            Name = name;
            Price = price;
            Color = color;
        }
    }
}
