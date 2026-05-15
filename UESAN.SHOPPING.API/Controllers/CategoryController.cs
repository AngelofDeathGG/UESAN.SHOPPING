using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infraestructure.Repositories;

namespace UESAN.SHOPPING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Listar categoría por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }
        // POST: Crear una nueva categoría
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
                if (categoryCreateDTO == null)
                {
                    return BadRequest();
                }

            await _categoryService.CreateCategory(categoryCreateDTO);
            return Ok();
        }

        // PUT: Actualizar una categoría existente
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            if (categoryUpdateDTO == null)
            {
                return BadRequest();
            }
            var existingCategory = await _categoryService.GetCategoryById(categoryUpdateDTO.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.UpdateCategory(categoryUpdateDTO);
            return NoContent();
        }

        // DELETE: Eliminar (desactivar) una categoría
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromBody] CategoryDeleteDTO categoryDeleteDTO)
        {
            var existingCategory = await _categoryService.GetCategoryById(categoryDeleteDTO.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.DeleteCategory(categoryDeleteDTO);
            return NoContent();
        }
    }

}


