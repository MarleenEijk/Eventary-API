using CORE.Dto;
using CORE.Interfaces;
using CORE.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unittest.Services
{
    [TestClass]
    public class ItemServiceTest
    {
        private Mock<IItemRepository>? _mockItemRepository;
        private ItemService? _itemService;

        [TestInitialize]
        public void Setup()
        {
            try
            {
                _mockItemRepository = new Mock<IItemRepository>();
                _itemService = new ItemService(_mockItemRepository.Object);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Setup failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task SimpleTest_ShouldPass()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task GetAllItems_ShouldReturnAllItems()
        {
            try
            {
                var items = new List<ItemDto>
                {
                    new ItemDto { Id = 1, Name = "Item1", Price = 10, Quantity = 5, ImageUrl = "url1.com", Category_Id = 1, Company_Id = 1 },
                    new ItemDto { Id = 2, Name = "Item2", Price = 20, Quantity = 10, ImageUrl = "url2.com", Category_Id = 2, Company_Id = 2 }
                };
                _mockItemRepository!.Setup(x => x.GetAllAsync()).ReturnsAsync(items);

                var result = await _itemService!.GetAllItemsAsync();

                Assert.AreEqual(2, result.Count());
                Assert.AreEqual("Item1", result.First().Name);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task GetItemById_ShouldReturnItem()
        {
            try
            {
                var item = new ItemDto { Id = 1, Name = "Item1", Price = 10, Quantity = 5, ImageUrl = "url1", Category_Id = 1, Company_Id = 1 };
                _mockItemRepository!.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(item);

                var result = await _itemService!.GetItemByIdAsync(1);

                Assert.IsNotNull(result);
                Assert.AreEqual("Item1", result.Name);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task AddItem_ShouldCallRepository()
        {
            try
            {
                var item = new ItemDto { Id = 1, Name = "NewItem", Price = 30, Quantity = 15, ImageUrl = "url3", Category_Id = 3, Company_Id = 3 };

                await _itemService!.AddItemAsync(item);

                _mockItemRepository!.Verify(x => x.AddItemAsync(item), Times.Once);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task UpdateItem_ShouldCallRepository()
        {
            try
            {
                var item = new ItemDto { Id = 1, Name = "UpdatedItem", Price = 40, Quantity = 20, ImageUrl = "url4", Category_Id = 4, Company_Id = 4 };

                await _itemService!.UpdateItemAsync(item);

                _mockItemRepository!.Verify(x => x.UpdateItemAsync(item), Times.Once);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task DeleteItem_ShouldCallRepository()
        {
            try
            {
                var itemId = 1;

                await _itemService!.DeleteItemAsync(itemId);

                _mockItemRepository!.Verify(x => x.DeleteItemAsync(itemId), Times.Once);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task GetItemById_ShouldReturnNull_WhenItemNotFound()
        {
            try
            {
                _mockItemRepository!.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((ItemDto?)null);

                var result = await _itemService!.GetItemByIdAsync(1);

                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task AddItem_ShouldThrowException_WhenRepositoryFails()
        {
            try
            {
                var item = new ItemDto { Id = 1, Name = "NewItem", Price = 30, Quantity = 15, ImageUrl = "url3", Category_Id = 3, Company_Id = 3 };
                _mockItemRepository!.Setup(x => x.AddItemAsync(item)).ThrowsAsync(new System.Exception("Repository failure"));

                await Assert.ThrowsExceptionAsync<System.Exception>(async () => await _itemService!.AddItemAsync(item));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task UpdateItem_ShouldThrowException_WhenRepositoryFails()
        {
            try
            {
                var item = new ItemDto { Id = 1, Name = "UpdatedItem", Price = 40, Quantity = 20, ImageUrl = "url4", Category_Id = 4, Company_Id = 4 };
                _mockItemRepository!.Setup(x => x.UpdateItemAsync(item)).ThrowsAsync(new System.Exception("Repository failure"));

                await Assert.ThrowsExceptionAsync<System.Exception>(async () => await _itemService!.UpdateItemAsync(item));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }

        [TestMethod]
        public async Task DeleteItem_ShouldThrowException_WhenRepositoryFails()
        {
            try
            {
                var itemId = 1;
                _mockItemRepository!.Setup(x => x.DeleteItemAsync(itemId)).ThrowsAsync(new System.Exception("Repository failure"));

                await Assert.ThrowsExceptionAsync<System.Exception>(async () => await _itemService!.DeleteItemAsync(itemId));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed: {ex.Message}");
            }
        }
    }
}
