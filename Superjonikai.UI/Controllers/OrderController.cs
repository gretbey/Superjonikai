using Microsoft.AspNetCore.Mvc;
using Superjonikai.Model.ActionFilters;
using Superjonikai.Model.DTO;
using Superjonikai.Model.IServices;
using System.Collections.Generic;

namespace Superjonikai.UI.Controllers
{
    [LogActionFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("/allOrders")]
        public ServerResult<List<Order>> Orders()
        {
            return _orderService.GetAll();
        }

        [HttpGet("/orders/{id}")]
        public ServerResult<Order> GetOrder([FromRoute] int id)
        {
            return _orderService.Get(id);
        }

        [HttpPut("/UpdateOrder")]
        public ServerResult<Order> UpdateOrder([FromBody] Order order)
        {
            if (order.ClientName == "" || order.Status == null || order.DeliveryDate == null)
            {
                return new ServerResult<Order>() { 
                    Success = false,
                    Message = "Unable to update order",
                };
            }
            else
            {
                return _orderService.UpdateOrder(order);
            }
        }

        [HttpGet("/clientOrders/{clientName}")]
        public ServerResult<List<Item>> GetItemsByClientName([FromRoute] string clientName)
        {
            return _orderService.GetItemsByClientName(clientName);
        }

        [HttpPost("/add/{item}")]
        public ServerResult<Order> AddToCart([FromBody] Item item)
        {
            if (item.Name == "" || item.Price == 0)
            {
                return new ServerResult<Order>() { 
                    Success = false,
                    Message = "Unable to add to cart",
                };
            }
            else
            {
                return _orderService.AddToCart(item);
            } 
        }

    }
}
