using Cars.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
            => this.service = service;

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
            => Ok(await service.GetCategoriesAsync());

        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategoryAsync([FromRoute] int id)
            => Ok(await service.GetCategoryAsync(id));

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] string name)
            => Ok(await service.CreateCategoryAsync(name));

        [HttpGet("GetByCar/{categoryId}")]
        public async Task<IActionResult> GetCategoryByCarAsync([FromRoute] int categoryId)
            => Ok(await service.GetCategoryByCarAsync(categoryId));
    }
}
