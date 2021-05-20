using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Repository;
using Superjonikai.Model.Entities.Order;
using System.Linq;

namespace Superjonikai.DB.SQLRepository
{
    public class OrderSqlRepository : IOrderRepository
    {
        private readonly DBContext context;

        public OrderSqlRepository(DBContext context)
        {
            this.context = context;
        }
        public Order Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {
            Order order = context.Orders.Find(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return order;
        }

        public Order Get(int id)
        {
            return context.Orders.Find(id);
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList<Order>();
        }

        public Order Update(Order updatedOrder)
        {
            var order = context.Orders.Attach(updatedOrder);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedOrder;
        }
    }
}
