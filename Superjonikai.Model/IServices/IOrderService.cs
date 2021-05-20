using Superjonikai.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.Model.IServices
{
    public interface IOrderService
    {
        ServerResult<List<Order>> GetAll();
        ServerResult<Order> Get(int id);
        ServerResult<Order> UpdateOrder(Order order);
    }
}
