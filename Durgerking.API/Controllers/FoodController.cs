using Azure.Core;
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
            var request = await service.GetProducts();
            return Ok(request);
        }
        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var request = await service.GetProduct(id);
            return Ok(request);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(Product newProduct)
        {
            var request = await service.CreateProduct(newProduct);
            return Ok(request);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var request = await service.DeleteProduct(id);
            return Ok(request);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var request = await service.UpdateProduct(product);
            return Ok(request);
        }
    }
}
