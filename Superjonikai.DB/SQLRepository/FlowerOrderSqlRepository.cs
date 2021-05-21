using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Repository;

namespace Superjonikai.DB.SQLRepository
{
    public class FlowerOrderSqlRepository : IFlowerOrderRepository
    {
        private readonly DBContext context;

        public FlowerOrderSqlRepository(DBContext context)
        {
            this.context = context;
        }

        public FlowerOrder Add(FlowerOrder entity)
        {
            throw new NotImplementedException();
        }

        public FlowerOrder Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FlowerOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<FlowerOrder> GetAll()
        {
            return context.FlowerOrders.ToList();
        }

        public FlowerOrder Update(FlowerOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
