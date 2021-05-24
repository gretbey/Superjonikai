using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Repository;

namespace Superjonikai.DB.SQLRepository
{
    public class BouquetOrderSqlRepository : IBouquetOrderRepository
    {
        private readonly DBContext context;

        public BouquetOrderSqlRepository(DBContext context)
        {
            this.context = context;
        }

        public BouquetOrder Add(BouquetOrder entity)
        {
            context.BouquetOrders.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public BouquetOrder Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BouquetOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BouquetOrder> GetAll()
        {
            return context.BouquetOrders.ToList();
        }

        public BouquetOrder Update(BouquetOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
