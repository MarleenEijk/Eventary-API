using CORE.Dto;
using CORE.Services;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest.TestServices
{
    public class OrderServiceTest
    {
        private readonly FakeOrderRepository _repository;
        private readonly OrderService _service;

        public OrderServiceTest()
        {
            _repository = new FakeOrderRepository();
            _service = new OrderService(_repository);
        }

        [Fact]
        public async Task AddOrderAsync_ShouldAddOrder()
        {
            var orderDto = new OrderDto
            {
                Id = 1,
                Name = "Order1",
                Address = "123 Street",
                Email = "test@example.com",
                Phone = "1234567890",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                company_Id = 1
            };

            await _service.AddOrderAsync(orderDto);

            var result = await _service.GetOrderByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Order1", result!.Name);
        }

        [Fact]
        public async Task AddOrderAsync_ShouldThrow_WhenStartDateIsAfterEndDate()
        {
            var orderDto = new OrderDto
            {
                Id = 1,
                Name = "Order1",
                Address = "123 Street",
                Email = "test@example.com",
                Phone = "1234567890",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now,
                company_Id = 1
            };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddOrderAsync(orderDto));
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldRemoveOrder()
        {
            var orderDto = new OrderDto
            {
                Id = 1,
                Name = "Order1",
                Address = "123 Street",
                Email = "test@example.com",
                Phone = "1234567890",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                company_Id = 1
            };

            await _service.AddOrderAsync(orderDto);
            await _service.DeleteOrderAsync(1);

            var result = await _service.GetOrderByIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateOrderAsync_ShouldUpdateOrder()
        {
            var orderDto = new OrderDto
            {
                Id = 1,
                Name = "Order1",
                Address = "123 Street",
                Email = "test@example.com",
                Phone = "1234567890",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                company_Id = 1
            };

            await _service.AddOrderAsync(orderDto);

            orderDto.Name = "UpdatedOrder";
            await _service.UpdateOrderAsync(orderDto);

            var result = await _service.GetOrderByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("UpdatedOrder", result!.Name);
        }
    }
}
