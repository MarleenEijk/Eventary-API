using CORE.Dto;
using CORE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class ItemTest
    {
        private readonly FakeItemRepository _repository;

        public ItemTest()
        {
            _repository = new FakeItemRepository();
        }

        [Fact]
        public async Task AddItemAsync_ShouldAddItem()
        {
            var itemDto = new ItemDto
            {
                Id = 1,
                Name = "Test Item",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "www.image.com",
                Category_Id = 1,
                Company_Id = 1
            };

            await _repository.AddItemAsync(itemDto);
            var items = await _repository.GetAllAsync();

            Assert.Single(items);
            Assert.Equal("Test Item", items.First().Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnItem()
        {
            var itemDto = new ItemDto
            {
                Id = 1,
                Name = "Test Item",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "www.image.com",
                Category_Id = 1,
                Company_Id = 1
            };
            await _repository.AddItemAsync(itemDto);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test Item", result.Name);
        }

        [Fact]
        public async Task UpdateItemAsync_ShouldUpdateItem()
        {
            var itemDto = new ItemDto
            {
                Id = 1,
                Name = "Test Item",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "www.image.com",
                Category_Id = 1,
                Company_Id = 1
            };
            await _repository.AddItemAsync(itemDto);

            var updatedItemDto = new ItemDto
            {
                Id = 1,
                Name = "Updated Item",
                Price = 15.0m,
                Quantity = 10,
                ImageUrl = "www.image.com",
                Category_Id = 2,
                Company_Id = 2
            };

            await _repository.UpdateItemAsync(updatedItemDto);
            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Updated Item", result.Name);
            Assert.Equal(15.0m, result.Price);
            Assert.Equal(10, result.Quantity);
        }

        [Fact]
        public async Task DeleteItemAsync_ShouldRemoveItem()
        {
            var itemDto = new ItemDto
            {
                Id = 1, 
                Name = "Test Item",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "www.image.com",
                Category_Id = 1,
                Company_Id = 1
            };
            await _repository.AddItemAsync(itemDto);

            await _repository.DeleteItemAsync(1);
            var result = await _repository.GetByIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoItemsAdded()
        {
            var items = await _repository.GetAllAsync();

            Assert.Empty(items);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenItemDoesNotExist()
        {
            var result = await _repository.GetByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateItemAsync_ShouldThrowException_WhenItemDoesNotExist()
        {
            var itemDto = new ItemDto
            {
                Id = 568,
                Name = "Table",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "www.image.com",
                Category_Id = 1,
                Company_Id = 1
            };

            await Assert.ThrowsAsync<Exception>(() => _repository.UpdateItemAsync(itemDto));
        }

        [Fact]
        public async Task DeleteItemAsync_ShouldThrowException_WhenItemDoesNotExist()
        {
            await Assert.ThrowsAsync<Exception>(() => _repository.DeleteItemAsync(999));
        }
    }
}
