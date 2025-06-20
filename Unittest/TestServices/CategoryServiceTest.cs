using CORE.Dto;
using CORE.Services;
using Unittest.FakeRepositories;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

namespace Unittest.TestServices
{
    public class CategoryServiceTest
    {
        private readonly CategoryService _service;
        private readonly FakeCategoryRpository _repository;

        public CategoryServiceTest()
        {
            _repository = new FakeCategoryRpository();
            _service = new CategoryService(_repository);
        }

        [Fact]
        public async Task GetAllCategoriesAsync_ShouldReturnAllCategories()
        {
            await _repository.AddCategoryAsync(new CategoryDto { Id = 1, Name = "Category A", Company_Id = 1 });
            await _repository.AddCategoryAsync(new CategoryDto { Id = 2, Name = "Category B", Company_Id = 1 });

            var result = await _service.GetAllCategoriesAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ShouldReturnCategory_WhenExists()
        {
            var category = new CategoryDto { Id = 1, Name = "TestCat", Company_Id = 1 };
            await _repository.AddCategoryAsync(category);
            
            var result = await _service.GetCategoryByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("TestCat", result!.Name);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            var result = await _service.GetCategoryByIdAsync(999);

            Assert.Null(result);
        }
    }
}
