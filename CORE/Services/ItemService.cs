using CORE.Dto;
using CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddItemAsync(ItemDto itemDto)
        {
            await _itemRepository.AddItemAsync(itemDto);
        }

        public async Task UpdateItemAsync(ItemDto itemDto)
        {
            await _itemRepository.UpdateItemAsync(itemDto);
        }

        public async Task DeleteItemAsync(long id)
        {
            await _itemRepository.DeleteItemAsync(id);
        }
    }
}
