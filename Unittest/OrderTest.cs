using CORE.Dto;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class OrderTest
    {
        private readonly FakeOrderRepository _repository;

        public OrderTest()
        {
            _repository = new FakeOrderRepository();
        }

        [Fact]
        public async Task AddOrderAsync_ShouldAddOrder()
        {
            var orderDto = new OrderDto
            {
                Id = 1,
                Name = "Test Order",
                Address = "testtraat 13",
                Email = "test@example.com",
                Phone = "0612345678",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = "bezorgd",
                Note = "test note",
                company_Id = 1
            };

            await _repository.AddOrderAsync(orderDto);
            var orders = await _repository.GetAllAsync();

            Assert.Single(orders);
            Assert.Equal("Test Order", orders.First().Name);
        }

        [Fact]
        public async Task GetOrderByIdAsync_ShouldReturnOrder()
        {
            var orderDto = new OrderDto { Id = 1, Name = "Test Order" };
            await _repository.AddOrderAsync(orderDto);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test Order", result.Name);
        }

        [Fact]
        public async Task UpdateOrderAsync_ShouldUpdateOrder()
        {
            var orderDto = new OrderDto { Id = 1, Name = "Test Order" };
            await _repository.AddOrderAsync(orderDto);

            var updatedOrder = new OrderDto { Id = 1, Name = "Updated Order" };
            await _repository.UpdateOrderAsync(updatedOrder);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Updated Order", result.Name);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldRemoveOrder()
        {
            var orderDto = new OrderDto { Id = 1, Name = "Test Order" };
            await _repository.AddOrderAsync(orderDto);

            await _repository.DeleteOrderAsync(1);
            var result = await _repository.GetByIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateOrderAsync_ShouldThrowException_WhenOrderDoesNotExist()
        {
            var nonExistentOrder = new OrderDto { Id = 999, Name = "Non-existent Order" };

            var exception = await Assert.ThrowsAsync<Exception>(async () =>
            {
                await _repository.UpdateOrderAsync(nonExistentOrder);
            });

            Assert.Equal("Order not found", exception.Message);
        }

    }
}
