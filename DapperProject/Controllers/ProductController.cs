using DapperProject.Dtos.ProductDtos;
using DapperProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return View(values);
        }
        public async Task<IActionResult> ProductListWithCategory()
        {
            return View(await _productRepository.GetAllProductWithCategory());
        }

        [HttpGet]
        public IActionResult CreateProduct()
        { return View(); }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            return View(await _productRepository.GetByIdProductAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productRepository.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }
    }
}
