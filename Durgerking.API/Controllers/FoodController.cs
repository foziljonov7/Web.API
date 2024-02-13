using Durgerking.API.Models;
using Durgerking.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Durgerking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IProductService service;

        public FoodController(IProductService service)
            => this.service = service;

        [HttpGet("GetProducts")] //malumot olish 
        public async Task<IActionResult> GetProducts()
        {
            var products = await service.GetProducts();
            return Ok(products);
        }
        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await service.GetProduct(id);
            return Ok(product);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product newProduct)
        {
            var product = await service.CreateProduct(newProduct);
            return Ok(product);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await service.DeleteProduct(id);
            return Ok(product);
        }
    }
}
