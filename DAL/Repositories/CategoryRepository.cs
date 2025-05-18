using CORE.Interfaces;
using CORE.Dto;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.category.ToListAsync();
            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Company_Id = category.Company_Id
            });
        }

        public async Task<CategoryDto?> GetByIdAsync(long id)
        {
            var category = await _context.category.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Company_Id = category.Company_Id
            };
        }
    }
}
