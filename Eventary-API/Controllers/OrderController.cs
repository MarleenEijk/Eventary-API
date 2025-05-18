using CORE.Dto;
using CORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eventary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            return await _orderService.GetAllOrdersAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<OrderDto?> GetOrderByIdAsync(long id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }

        [HttpPost]
        public async Task AddOrderAsync(OrderDto orderDto)
        {
            await _orderService.AddOrderAsync(orderDto);
        }

        [HttpPut]
        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            await _orderService.UpdateOrderAsync(orderDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteOrderAsync(long id)
        {
            await _orderService.DeleteOrderAsync(id);
        }

    }
}
