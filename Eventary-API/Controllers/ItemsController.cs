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
        [ProducesResponseType<List<ItemDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
        {
            return await _itemService.GetAllItemsAsync();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<ItemDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ItemDto?> GetItemByIdAsync(long id)
        {
            return await _itemService.GetItemByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType<ItemDto>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItemAsync([FromBody]ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _itemService.AddItemAsync(itemDto);
            return CreatedAtAction(nameof(GetItemByIdAsync), new { id = itemDto.Id }, itemDto);
        }
  
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task UpdateItemAsync(ItemDto itemDto)
        { 
            await _itemService.UpdateItemAsync(itemDto);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeleteItemAsync(long id)
        {
            await _itemService.DeleteItemAsync(id);
        }

    }
}
