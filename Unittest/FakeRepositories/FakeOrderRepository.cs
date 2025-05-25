using CORE.Dto;
using CORE.Interfaces;

namespace Unittest.FakeRepositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        private readonly List<OrderDto> _orders = new();

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await Task.FromResult(_orders);
        }

        public async Task<OrderDto?> GetByIdAsync(long id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            return await Task.FromResult(order);
        }

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            _orders.Add(orderDto);
            await Task.CompletedTask;
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == orderDto.Id);
            if (existingOrder == null)
            {
                throw new Exception("Order not found");
            }

            existingOrder.Name = orderDto.Name;
            existingOrder.Address = orderDto.Address;
            existingOrder.Email = orderDto.Email;
            existingOrder.Phone = orderDto.Phone;
            existingOrder.StartDate = orderDto.StartDate;
            existingOrder.EndDate = orderDto.EndDate;
            existingOrder.Status = orderDto.Status;
            existingOrder.Note = orderDto.Note;
            existingOrder.company_Id = orderDto.company_Id;

            await Task.CompletedTask;
        }

        public async Task DeleteOrderAsync(long id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            _orders.Remove(order);
            await Task.CompletedTask;
        }
    }
}
