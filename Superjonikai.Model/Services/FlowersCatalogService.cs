using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Entities;

namespace Superjonikai.Model.Services
{
    public class FlowersCatalogService: IFlowersCatalogService
    {
        public List<Flower> Get()
        {
            var tmpList = new List<Flower>
            {
                new Flower("lelija", 2.35, "geltona"),
                new Flower("tulpe", 1.55, "raudona"),
                new Flower("tulpe", 1.55, "geltona")
            };
            return tmpList;
        }
    }
}
