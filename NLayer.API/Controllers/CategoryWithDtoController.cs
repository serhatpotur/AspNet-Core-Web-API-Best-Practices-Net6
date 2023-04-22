using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Dtos;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{
    
    public class CategoryWithDtoController : CustomBaseController
    {
        private readonly IServiceWithDto<Category, CategoryDto> _serviceWithDto;

        public CategoryWithDtoController(IServiceWithDto<Category, CategoryDto> serviceWithDto)
        {
            _serviceWithDto = serviceWithDto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _serviceWithDto.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto CategoryDto)
        {
            return CreateActionResult(await _serviceWithDto.AddAsync(CategoryDto));
        }
    }
}
