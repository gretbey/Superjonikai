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
        private readonly IBouquetOrderRepository _bouquetOrderRepo;
        private readonly IFlowerOrderRepository _flowerOrderRepo;
        private readonly IFlowerRepository _flowerRepo;
        private readonly IBouquetRepository _bouquetRepo;


        public OrderService(IOrderRepository orderRepo, IBouquetOrderRepository bouquetOrderRepo, IFlowerOrderRepository flowerOrderRepo, IFlowerRepository flowerRepo, IBouquetRepository bouquetRepo)
        {
            _orderRepo = orderRepo;
            _bouquetOrderRepo = bouquetOrderRepo;
            _flowerOrderRepo = flowerOrderRepo;
            _flowerRepo = flowerRepo;
            _bouquetRepo = bouquetRepo;
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

        public ServerResult<List<Item>> GetItemsByClientName(string clientName)
        {
            var orderId = _orderRepo.GetAll().Where(t => t.ClientName == clientName).Select(t => t.Id).Last();
            List<Item> allItems = new List<Item>();
            Bouquet bouquet;
            Flower flower;
            var orderBouquets = _bouquetOrderRepo.GetAll().Where(t => t.OrderId == orderId);
            var orderFlowers = _flowerOrderRepo.GetAll().Where(t => t.OrderId == orderId);
            foreach (var orderBouquet in orderBouquets)
            {
                bouquet = _bouquetRepo.Get(orderBouquet.BouquetId).ToDTO();
                bouquet.Size = orderBouquet.Size;
                if (bouquet.Size.ToLower() == "medium")
                {
                    bouquet.TotalPrice = Math.Round(bouquet.Price * 1.5, 2);
                }
                else if (bouquet.Size.ToLower() == "large")
                {
                    bouquet.TotalPrice = Math.Round(bouquet.Price * 2, 2);
                }
                else
                {
                    bouquet.TotalPrice = Math.Round(bouquet.Price, 2);
                }
                allItems.Add(bouquet);
            }
            foreach (var orderFlower in orderFlowers)
            {
                flower = _flowerRepo.Get(orderFlower.FlowerId).ToDTO();
                flower.Quantity = orderFlower.Quantity;
                flower.TotalPrice = Math.Round(flower.Quantity * flower.Price, 2);
                allItems.Add(flower);
            }
            return new ServerResult<List<Item>>
            {
                Data = allItems,
                Success = true
            };
        }

    }
}
