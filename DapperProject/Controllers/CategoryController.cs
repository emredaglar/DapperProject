using DapperProject.Dtos;
using DapperProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
  
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> CategoryList()
        {
            var values=await _categoryRepository.GetAllCategoryAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _categoryRepository.GetByIdCategoryAsync(id);

            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("Index");
        }

    }
}
