using System.Collections.Generic;
using System.Threading.Tasks;
using CORE.Dto;

namespace CORE.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(long id);
    }
}
