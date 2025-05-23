﻿using CORE.Dto;
using Microsoft.AspNetCore.Mvc;
using CORE.Services;

namespace Eventary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _categoryService.GetAllCategoriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto?> GetCategoryByIdAsync(long id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }
    }
}
