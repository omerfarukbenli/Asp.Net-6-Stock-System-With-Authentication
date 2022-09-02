using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StokApp.Business.Abstract;
using StokApp.Entities.Concrete.Dtos;

namespace StokApp.Api.Controllers
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
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryId(int id)
        {
            return Ok(await _categoryService.GetCategoriesID(id));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllCategory()
        {
            return Ok(await _categoryService.GetAllCategory());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto)
        {
            return Ok(await _categoryService.Post(categoryDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto categoryDto)
        {

            return Ok(await _categoryService.Update(categoryDto, id));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _categoryService.DeleteByIdAsync(id));

        }
    
    }
}
