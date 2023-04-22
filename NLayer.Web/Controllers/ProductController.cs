using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.Dtos;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Web.Filters;
using NLayer.Web.Services;
using System.Net.WebSockets;

namespace NLayer.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productApiService.GetProductsWithCategoryAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.AddAsync(productDto);
                return RedirectToAction(nameof(Index));

            }
            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryApiService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name", productDto.CategoryId);
            return View(productDto);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}
