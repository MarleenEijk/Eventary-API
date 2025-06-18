using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CORE.Dto;
using FluentAssertions;
using Xunit;

namespace IntergrationTests.Controllers
{
    public class ItemControllerTests
    {
        private readonly HttpClient _client;

        public ItemControllerTests()
        {
            var factory = new EventaryWebApplicationFactory();
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddItem_ReturnsCreatedAndCanBeCalled()
        {
            var newItem = new ItemDto
            {
                Id = 0,
                Name = "Test Item",
                Price = 4,
                Quantity = 10,
                ImageUrl = "https://image/image.png",
                Category_Id = 1,
                Company_Id = 1
            };

            var postResponse = await _client.PostAsJsonAsync("/api/items", newItem);

            postResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdItem = await postResponse.Content.ReadFromJsonAsync<ItemDto>();
            createdItem.Should().NotBeNull();
            createdItem!.Id.Should().BeGreaterThan(0);

            var getResponse = await _client.GetAsync($"/api/items/{createdItem.Id}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var fetchedItem = await getResponse.Content.ReadFromJsonAsync<ItemDto>();

            fetchedItem.Should().NotBeNull();
            fetchedItem!.Name.Should().Be("Test Item");
            fetchedItem.Price.Should().Be(4);
        }

        [Fact]
        public async Task GetAllItems_ReturnsListOfItems()
        {
            var newItem = new ItemDto
            {
                Id = 0,
                Name = "Item voor lijst",
                Price = 3,
                Quantity = 5,
                ImageUrl = "https://image/image.png",
                Category_Id = 1,
                Company_Id = 1
            };

            await _client.PostAsJsonAsync("/api/items", newItem);

            var response = await _client.GetAsync("/api/items");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var items = await response.Content.ReadFromJsonAsync<List<ItemDto>>();
            items.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task UpdateItem_ReturnsOkAndUpdatesData()
        {
            var newItem = new ItemDto
            {
                Id = 0,
                Name = "Old Name",
                Price = 5,
                Quantity = 2,
                ImageUrl = "https://image/image.png",
                Category_Id = 1,
                Company_Id = 1
            };

            var postResponse = await _client.PostAsJsonAsync("/api/items", newItem);
            var createdItem = await postResponse.Content.ReadFromJsonAsync<ItemDto>();

            createdItem!.Name = "Updated Name";
            createdItem.Price = 10;

            var updateResponse = await _client.PutAsJsonAsync($"/api/items/{createdItem.Id}", createdItem);

            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"/api/items/{createdItem.Id}");
            var updatedItem = await getResponse.Content.ReadFromJsonAsync<ItemDto>();

            updatedItem!.Name.Should().Be("Updated Name");
            updatedItem.Price.Should().Be(10);
        }

        [Fact]
        public async Task DeleteItem_RemovesItemSuccessfully()
        {
            var newItem = new ItemDto
            {
                Id = 0,
                Name = "To be deleted",
                Price = 6,
                Quantity = 1,
                ImageUrl = "https://image/image.png",
                Category_Id = 1,
                Company_Id = 1
            };

            var postResponse = await _client.PostAsJsonAsync("/api/items", newItem);
            var createdItem = await postResponse.Content.ReadFromJsonAsync<ItemDto>();

            var deleteResponse = await _client.DeleteAsync($"/api/items/{createdItem!.Id}");

            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await _client.GetAsync($"/api/items/{createdItem.Id}");
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task AddItem_WithMissingName_ReturnsBadRequest()
        {
            var invalidItem = new ItemDto
            {
                Id = 0,
                Name = "",
                Price = 4,
                Quantity = 10,
                ImageUrl = "https://image/image.png",
                Category_Id = 1,
                Company_Id = 1
            };

            var response = await _client.PostAsJsonAsync("/api/items", invalidItem);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetItem_NonExistingId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/items/4856445");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateItem_NonExistingId_ReturnsNotFound()
        {
            var nonExistingItem = new ItemDto
            {
                Id = 489654,
                Name = "No Item",
                Price = 5,
                Quantity = 2,
                ImageUrl = "https://image/image.png",
                Category_Id = 1,
                Company_Id = 1
            };

            var response = await _client.PutAsJsonAsync("/api/items/99999", nonExistingItem);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task DeleteItem_NonExistingId_ReturnsNotFound()
        {
            var response = await _client.DeleteAsync("/api/items/484654");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
