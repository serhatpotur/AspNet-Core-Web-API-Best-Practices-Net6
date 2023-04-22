using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.Dtos;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAllAsync();
            var mappedCategoryDto = _mapper.Map<List<CategoryDto>>(category.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, mappedCategoryDto));
        }

        //api/category/GetSingleCategoryByIdWithProductsAsync/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId);
            return CreateActionResult(category);
        }
    }
}
