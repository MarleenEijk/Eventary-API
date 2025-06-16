using CORE.Dto;
using CORE.Interfaces;

namespace CORE.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(long id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            ValidateOrderDates(orderDto);
            await _orderRepository.AddOrderAsync(orderDto);
        }

        public async Task DeleteOrderAsync(long id)
        {
            await EnsureOrderExists(id);
            await _orderRepository.DeleteOrderAsync(id);
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            await EnsureOrderExists(orderDto.Id);
            await _orderRepository.UpdateOrderAsync(orderDto);
        }

        private void ValidateOrderDates(OrderDto orderDto)
        {
            if (orderDto.StartDate >= orderDto.EndDate)
            {
                throw new ArgumentException("StartDate must be earlier than EndDate.");
            }
        }

        private async Task EnsureOrderExists(long id)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }
        }
    }
}
