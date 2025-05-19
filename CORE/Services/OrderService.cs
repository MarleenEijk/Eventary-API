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
            if (orderDto.StartDate >= orderDto.EndDate)
            {
                throw new ArgumentException("StartDate must be earlier than EndDate.");
            }

            await _orderRepository.AddOrderAsync(orderDto);
        }

        public async Task DeleteOrderAsync(long id)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }

            await _orderRepository.DeleteOrderAsync(id);
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderDto.Id);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }

            await _orderRepository.UpdateOrderAsync(orderDto);
        }
    }
}
