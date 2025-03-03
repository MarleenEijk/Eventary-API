using CORE.Dto;
using CORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eventary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
        {
            return await _itemService.GetAllItemsAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ItemDto?> GetItemByIdAsync(long id)
        {
            return await _itemService.GetItemByIdAsync(id);
        }

        [HttpPost]
        public async Task AddItemAsync(ItemDto itemDto)
        {
            await _itemService.AddItemAsync(itemDto);
        }
  
        [HttpPut]
        public async Task UpdateItemAsync(ItemDto itemDto)
        {
            await _itemService.UpdateItemAsync(itemDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteItemAsync(long id)
        {
            await _itemService.DeleteItemAsync(id);
        }

    }
}
