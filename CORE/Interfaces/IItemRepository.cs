using CORE.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<ItemDto?> GetByIdAsync(long id);
        Task AddItemAsync(ItemDto itemDto);
        Task DeleteItemAsync(long id);
        Task UpdateItemAsync(ItemDto itemDto);
        Task<ItemDto?> GetByNameAsync(string name);
    }
}
