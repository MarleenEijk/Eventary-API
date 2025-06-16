using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _context.order.ToListAsync();
            return orders.Select(order => new OrderDto
            {
                Id = order.Id,
                Name = order.Name,
                Address = order.Address,
                Email = order.Email,
                Phone = order.Phone,
                StartDate = order.StartDate,
                EndDate = order.EndDate,
                Status = order.Status,
                Note = order.Note,
                company_Id = order.company_Id
            });
        }

        public async Task<OrderDto?> GetByIdAsync(long id)
        {
            var order = await _context.order.FindAsync(id);
            if (order == null)
            {
                return null;
            }

            return new OrderDto
            {
                Id = order.Id,
                Name = order.Name,
                Address = order.Address,
                Email = order.Email,
                Phone = order.Phone,
                StartDate = order.StartDate,
                EndDate = order.EndDate,
                Status = order.Status,
                Note = order.Note,
                company_Id = order.company_Id
            };
        }

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                Name = orderDto.Name,
                Address = orderDto.Address,
                Email = orderDto.Email,
                Phone = orderDto.Phone,
                StartDate = orderDto.StartDate,
                EndDate = orderDto.EndDate,
                Status = orderDto.Status,
                Note = orderDto.Note,
                company_Id = orderDto.company_Id
            };

            await _context.order.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            var order = await _context.order.FindAsync(orderDto.Id);
            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            order.Name = orderDto.Name;
            order.Address = orderDto.Address;
            order.Email = orderDto.Email;
            order.Phone = orderDto.Phone;
            order.StartDate = orderDto.StartDate;
            order.EndDate = orderDto.EndDate;
            order.Status = orderDto.Status;
            order.Note = orderDto.Note;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(long id)
        {
            var order = await _context.order.FindAsync(id);
            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            _context.order.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
