using CORE.Dto;
using CORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eventary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
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

        [HttpGet("{id}", Name = "GetItemById")]
        [ProducesResponseType<ItemDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemByIdAsync(long id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType<ItemDto>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItemAsync([FromBody] ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedItem = await _itemService.AddItemAsync(itemDto);

            if (addedItem.Id <= 0)
            {
                return BadRequest("Failed to create the item. Invalid ID.");
            }

            return CreatedAtAction("GetItemById", new { id = addedItem.Id }, addedItem);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateItemAsync(ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingItem = await _itemService.GetItemByIdAsync(itemDto.Id);
            if (existingItem == null)
            {
                return NotFound("Item not found.");
            }

            await _itemService.UpdateItemAsync(itemDto);
            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteItemAsync(long id)
        {
            var existingItem = await _itemService.GetItemByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound("Item not found.");
            }

            await _itemService.DeleteItemAsync(id);
            return Ok();
        }


    }
}
