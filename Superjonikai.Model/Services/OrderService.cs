using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using Superjonikai.Model.Repository;
using Superjonikai.Model.PriceStrategy;


namespace Superjonikai.Model.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IBouquetOrderRepository _bouquetOrderRepo;
        private readonly IFlowerOrderRepository _flowerOrderRepo;
        private readonly IFlowerRepository _flowerRepo;
        private readonly IBouquetRepository _bouquetRepo;
        private readonly IConfiguration _configuration;


        public OrderService(IOrderRepository orderRepo, IBouquetOrderRepository bouquetOrderRepo, IFlowerOrderRepository flowerOrderRepo, IFlowerRepository flowerRepo, IBouquetRepository bouquetRepo, IConfiguration configuration)
        {
            _orderRepo = orderRepo;
            _bouquetOrderRepo = bouquetOrderRepo;
            _flowerOrderRepo = flowerOrderRepo;
            _flowerRepo = flowerRepo;
            _bouquetRepo = bouquetRepo;
            _configuration = configuration;
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
            var kk = _configuration.GetValue<string>("PriceStategy");
            Type priceStrategy = Type.GetType("Superjonikai.Model.PriceStrategy." + _configuration.GetValue<string>("PriceStategy"));
            var priceStrategyInstance = (ITotalItemPriceCalculator)Activator.CreateInstance(priceStrategy);
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
                bouquet.TotalPrice = priceStrategyInstance.CalculatePrice(bouquet);
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
                flower.TotalPrice = priceStrategyInstance.CalculatePrice(flower);
                allItems.Add(flower);
            }
            return new ServerResult<List<Item>>
            {
                Data = allItems,
                Success = true
            };
        }

        public ServerResult<Order> AddToCart(Item item)
        {
            try
            {
                DateTime date = DateTime.Now;
                string clientName = "TitasGrigaitis";
                var lastId = _orderRepo.GetAll().Last().Id;
                var userOrder = _orderRepo.GetAll().Where(t => t.ClientName == clientName);
                if (userOrder.Count() == 0)
                {
                    Entities.Order.Order order = new Entities.Order.Order()
                    {
                        Id = lastId + 1,
                        ClientName = clientName,
                        Status = Entities.Order.OrderStatus.Processing,
                        DeliveryDate = DateTime.Now,
                    };
                    _orderRepo.Add(order);
                    if (item.Quantity != 0) // so it is flower not bouquet
                    {
                        Entities.FlowerOrder flowerOrder = new Entities.FlowerOrder()
                        {
                            FlowerId = item.Id,
                            OrderId = lastId + 1,
                            Quantity = item.Quantity,
                        };
                        _flowerOrderRepo.Add(flowerOrder);
                    }
                    else
                    {
                        Entities.BouquetOrder bouquetOrder = new Entities.BouquetOrder()
                        {
                            BouquetId = item.Id,
                            OrderId = lastId + 1,
                            Size = item.Size
                        };
                        _bouquetOrderRepo.Add(bouquetOrder);
                    }
                }
                else
                {
                    if (item.Quantity != 0)
                    {
                        Entities.FlowerOrder flowerOrder = new Entities.FlowerOrder()
                        {
                            FlowerId = item.Id,
                            OrderId = userOrder.Last().Id,
                            Quantity = item.Quantity,
                        };
                        _flowerOrderRepo.Add(flowerOrder);
                    }
                    else
                    {
                        Entities.BouquetOrder bouquetOrder = new Entities.BouquetOrder()
                        {
                            BouquetId = item.Id,
                            OrderId = userOrder.Last().Id,
                            Size = item.Size
                        };
                        _bouquetOrderRepo.Add(bouquetOrder);
                    }
                }

                return new ServerResult<Order>() { Success = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot update database" + ex.Message);
                return new ServerResult<Order>() { Success = false };
            }
        }
    }
}
