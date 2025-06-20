﻿using CORE.Dto;
using Unittest.FakeRepositories;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

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

            await _repository.AddCategoryAsync(categoryDto);
            var categories = await _repository.GetAllAsync();

            Assert.Single(categories);
            Assert.Equal("Test Category", categories.First().Name);
        }

        [Fact]
        public async Task GetCategoryByIdAsync_ShouldReturnCategory()
        {
            var categoryDto = new CategoryDto { Id = 1, Name = "Test Category", Company_Id = 1 };
            await _repository.AddCategoryAsync(categoryDto);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test Category", result!.Name);
        }

        [Fact]
        public async Task RemoveCategory_ShouldRemoveCategory()
        {
            var categoryDto = new CategoryDto { Id = 1, Name = "Test Category", Company_Id = 1 };
            await _repository.AddCategoryAsync(categoryDto);

            await _repository.RemoveCategoryAsync(1);
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
            await _repository.RemoveCategoryAsync(999);
            var result = await _repository.GetByIdAsync(999);
            Assert.Null(result);
        }
    }
}
