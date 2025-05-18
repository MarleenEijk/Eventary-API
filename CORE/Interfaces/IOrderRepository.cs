using CORE.Dto;

namespace CORE.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(long id);
        Task AddOrderAsync(OrderDto orderDto);
        Task DeleteOrderAsync(long id);
        Task UpdateOrderAsync(OrderDto orderDto);
    }
}
