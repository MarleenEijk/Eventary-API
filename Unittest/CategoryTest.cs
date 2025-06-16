using CORE.Dto;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class CategoryTest
    {
        private readonly FakeCategoryRpository _repository;

        public CategoryTest()
        {
            _repository = new FakeCategoryRpository();
        }

        [Fact]
        public async Task AddCategory_ShouldAddCategory()
        {
            var categoryDto = new CategoryDto { Id = 1, Name = "Test Category", Company_Id = 1 };

            _repository.AddCategory(categoryDto);
            var categories = await _repository.GetAllAsync();

            Assert.Single(categories);
            Assert.Equal("Test Category", categories.First().Name);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ShouldReturnCategory()
        {
            var categoryDto = new CategoryDto { Id = 1, Name = "Test Category", Company_Id = 1 }; // Added Company_Id
            _repository.AddCategory(categoryDto);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test Category", result.Name);
        }

        [Fact]
        public async Task RemoveCategory_ShouldRemoveCategory()
        {
            var categoryDto = new CategoryDto { Id = 1, Name = "Test Category", Company_Id = 1 }; // Added Company_Id
            _repository.AddCategory(categoryDto);

            _repository.RemoveCategory(1);
            var result = await _repository.GetByIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            var result = await _repository.GetByIdAsync(999);
            Assert.Null(result);
        }

        [Fact]
        public async Task RemoveCategory_ShouldNotThrow_WhenCategoryDoesNotExist()
        {
            _repository.RemoveCategory(999);
            var result = await _repository.GetByIdAsync(999);
            Assert.Null(result);
        }
    }
}
