using Cars.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldController : ControllerBase
    {
        private readonly ISoldService service;

        public SoldController(ISoldService service)
            => this.service = service;

        [HttpGet("GetSolds")]
        public async Task<IActionResult> GetSoldsAsync()
            => Ok(await service.GetSoldsAsync());

        [HttpGet("GetSold/{id}")]
        public async Task<IActionResult> GetSoldAsync([FromRoute] Guid id)
            => Ok(await service.GetSoldAsync(id));

        [HttpGet("Sold/{carId}")]
        public async Task<IActionResult> GetSoldAsync(
            [FromRoute] Guid carId,
            int quantity)
                => Ok(await service.SoldAsync(carId, quantity));
    }
}
