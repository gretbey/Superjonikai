using Superjonikai.DB;
using Superjonikai.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Superjonikai.Model.Repository;

namespace Superjonikai.DB.SqlRepository
{
    public class FlowerSqlRepository : IFlowerRepository
    {
        private readonly DBContext context;

        public FlowerSqlRepository(DBContext context)
        {
            this.context = context;
        }
        public Flower Add(Flower flower)
        {
            context.Flowers.Add(flower);
            context.SaveChanges();
            return flower;
        }

        public Flower Delete(int id)
        {
            Flower flower = context.Flowers.Find(id);
            if (flower != null)
            {
                context.Flowers.Remove(flower);
                context.SaveChanges();
            }
            return flower;
        }

        public Flower Get(int id)
        {
            return context.Flowers.Find(id);
        }

        public List<Flower> GetAll()
        {
            return context.Flowers.ToList();
        }

        public Flower Update(Flower updatedFlower)
        {
            var flower = context.Flowers.Attach(updatedFlower);
            flower.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedFlower;
        }
    }
}