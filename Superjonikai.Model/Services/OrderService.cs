using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;


namespace Superjonikai.Model.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public ServerResult<Order> Get(int id)
        {
            Entities.Order.Order order = _orderRepo.Get(id);
            return new ServerResult<Order>
            {
                Data = order.ToDTO(),
                Success = true
            };
        }

        public ServerResult<List<Order>> GetAll()
        {
            var orders = _orderRepo.GetAll();
            return new ServerResult<List<Order>>
            {
                Data = orders.Select(t => t.ToDTO()).ToList(),
                Success = true
            };
        }

        public ServerResult<Order> UpdateOrder(Order order)
        {
            try
            {
                Entities.Order.Order orderDB = _orderRepo.Get(order.Id);
                if (orderDB == null)
                    return new ServerResult<Order>()
                    {
                        Success = false,
                        Message = "Order does not exist",
                    };

                if (order.RowVersion != null && !order.RowVersion.SequenceEqual(orderDB.RowVersion))
                {
                    return new ServerResult<Order>()
                    {
                        Success = false,
                        Message = "Already updated. Try again.",
                        Data = new Order { ClientName = orderDB.ClientName, DeliveryDate = orderDB.DeliveryDate.ToString(), RowVersion = orderDB.RowVersion }
                    };
                }

                Enum.TryParse(order.Status, out Entities.Order.OrderStatus newStatus);
                orderDB.Status = newStatus;
                orderDB.RowVersion = order.RowVersion;
                _orderRepo.Update(orderDB);
                return new ServerResult<Order>() { Success = true };
            }

            catch (Exception e)
            {
                return new ServerResult<Order>()
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
