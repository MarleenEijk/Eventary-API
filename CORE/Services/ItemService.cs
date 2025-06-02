    using CORE.Dto;
using CORE.Interfaces;
using CORE.Services;


namespace CORE.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }   

        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<ItemDto?> GetItemByIdAsync(long id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task<ItemDto> AddItemAsync(ItemDto itemDto)
        {
            var existingItem = await _itemRepository.GetByNameAsync(itemDto.Name);
            if (existingItem != null)
            {
                throw new ArgumentException("An item with the same name already exists.");
            }

            if (itemDto.Quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }
            if (itemDto.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            var addedItem = await _itemRepository.AddItemAsync(itemDto);
            return addedItem;
        }

        public async Task UpdateItemAsync(ItemDto itemDto)
        {
            var existingItem = await _itemRepository.GetByNameAsync(itemDto.Name);
            if (existingItem != null)
            {
                throw new ArgumentException("An item with the same name already exists.");
            }

            if (itemDto.Quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }
            if (itemDto.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            await _itemRepository.UpdateItemAsync(itemDto);
        }

        public async Task DeleteItemAsync(long id)
        {
            await _itemRepository.DeleteItemAsync(id);
        }
    }
}
