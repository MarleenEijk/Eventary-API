using CORE.Dto;
using CORE.Services;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class ItemServiceTest
    {
        private readonly FakeItemRepository _repository;
        private readonly ItemService _service;

        public ItemServiceTest()
        {
            _repository = new FakeItemRepository();
            _service = new ItemService(_repository);
        }

        [Fact]
        public async Task AddItemAsync_ShouldAddItem_WhenValid()
        {
            var itemDto = new ItemDto
            {
                Id = 1,
                Name = "Item A",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };

            var result = await _service.AddItemAsync(itemDto);

            Assert.NotNull(result);
            Assert.Equal("Item A", result.Name);
        }

        [Fact]
        public async Task AddItemAsync_ShouldThrow_WhenDuplicateName()
        {
            var itemDto = new ItemDto
            {
                Id = 1,
                Name = "Duplicate",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };

            await _service.AddItemAsync(itemDto);

            var duplicate = new ItemDto
            {
                Id = 2,
                Name = "Duplicate",
                Price = 15.0m,
                Quantity = 2,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddItemAsync(duplicate));
        }

        [Fact]
        public async Task AddItemAsync_ShouldThrow_WhenNegativeQuantity()
        {
            var itemDto = new ItemDto
            {
                Id = 1,
                Name = "Item B",
                Price = 10.0m,
                Quantity = -1,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddItemAsync(itemDto));
        }

        [Fact]
        public async Task AddItemAsync_ShouldThrow_WhenNegativePrice()
        {
            var itemDto = new ItemDto
            {
                Id = 1,
                Name = "Item C",
                Price = -1.0m,
                Quantity = 5,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddItemAsync(itemDto));
        }

        [Fact]
        public async Task UpdateItemAsync_ShouldUpdate_WhenValid()
        {
            var original = new ItemDto
            {
                Id = 1,
                Name = "Item D",
                Price = 10.0m,
                Quantity = 5,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };
            await _service.AddItemAsync(original);

            var updated = new ItemDto
            {
                Id = 1,
                Name = "Item D Updated",
                Price = 20.0m,
                Quantity = 10,
                ImageUrl = "url2",
                Category_Id = 2,
                Company_Id = 2
            };

            await _service.UpdateItemAsync(updated);
            var result = await _service.GetItemByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Item D Updated", result!.Name);
        }

        [Fact]
        public async Task UpdateItemAsync_ShouldThrow_WhenDuplicateNameWithDifferentId()
        {
            await _service.AddItemAsync(new ItemDto
            {
                Id = 1,
                Name = "Name1",
                Price = 5,
                Quantity = 1,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            });

            await _service.AddItemAsync(new ItemDto
            {
                Id = 2,
                Name = "Name2",
                Price = 5,
                Quantity = 1,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            });

            var duplicate = new ItemDto
            {
                Id = 2,
                Name = "Name1", // Duplicate name
                Price = 5,
                Quantity = 1,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateItemAsync(duplicate));
        }

        [Fact]
        public async Task UpdateItemAsync_ShouldThrow_WhenNegativePrice()
        {
            var item = new ItemDto
            {
                Id = 1,
                Name = "Item E",
                Price = 10,
                Quantity = 5,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };
            await _service.AddItemAsync(item);

            item.Price = -5;

            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateItemAsync(item));
        }

        [Fact]
        public async Task UpdateItemAsync_ShouldThrow_WhenNegativeQuantity()
        {
            var item = new ItemDto
            {
                Id = 1,
                Name = "Item F",
                Price = 10,
                Quantity = 5,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };
            await _service.AddItemAsync(item);

            item.Quantity = -3;

            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateItemAsync(item));
        }

        [Fact]
        public async Task GetItemByIdAsync_ShouldReturnItem()
        {
            var item = new ItemDto
            {
                Id = 1,
                Name = "Item G",
                Price = 10,
                Quantity = 2,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };
            await _service.AddItemAsync(item);

            var result = await _service.GetItemByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Item G", result!.Name);
        }

        [Fact]
        public async Task GetAllItemsAsync_ShouldReturnAll()
        {
            await _service.AddItemAsync(new ItemDto
            {
                Id = 1,
                Name = "Item H",
                Price = 10,
                Quantity = 2,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            });

            await _service.AddItemAsync(new ItemDto
            {
                Id = 2,
                Name = "Item I",
                Price = 20,
                Quantity = 4,
                ImageUrl = "url2",
                Category_Id = 1,
                Company_Id = 1
            });

            var result = await _service.GetAllItemsAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task DeleteItemAsync_ShouldRemoveItem()
        {
            var item = new ItemDto
            {
                Id = 1,
                Name = "Item J",
                Price = 10,
                Quantity = 2,
                ImageUrl = "url",
                Category_Id = 1,
                Company_Id = 1
            };

            await _service.AddItemAsync(item);
            await _service.DeleteItemAsync(1);

            var result = await _service.GetItemByIdAsync(1);
            Assert.Null(result);
        }
    }
}
