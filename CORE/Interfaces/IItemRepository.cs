using CORE.Dto;

namespace CORE.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<ItemDto?> GetByIdAsync(long id);
        Task<ItemDto> AddItemAsync(ItemDto itemDto);
        Task DeleteItemAsync(long id);
        Task UpdateItemAsync(ItemDto itemDto);
        Task<ItemDto?> GetByNameAsync(string name);
    }
}

