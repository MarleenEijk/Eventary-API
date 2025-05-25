using CORE.Dto;
using CORE.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unittest.FakeRepositories
{
    public class FakeCategoryRpository : ICategoryRepository
    {
        private readonly List<CategoryDto> _categories = new();

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await Task.FromResult(_categories);
        }

        public async Task<CategoryDto?> GetByIdAsync(long id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(category);
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            _categories.Add(categoryDto);
        }

        public void RemoveCategory(long id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
