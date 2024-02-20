using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile.API.Dtos;
using Mobile.API.Services;

namespace Mobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService service;

        public PhoneController(IPhoneService service)
            => this.service = service;

        [HttpGet("Products")]
        public async Task<IActionResult> GetPhonesAsync()
            => Ok(await service.GetPhonesAsync());

        [HttpGet("Phone/{id}")]
        public async Task<IActionResult> GetPhoneAsync([FromRoute] Guid id)
            => Ok(await service.GetPhoneAsync(id));

        [HttpGet("Sales/{id}")]
        public async Task<IActionResult> SalesPhoneAsync(
            [FromRoute] Guid id,
            int quantity)
                => Ok(await service.SalesPhoneAsync(id, quantity));

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePhoneAsync([FromBody] CreatePhoneDto newPhone)
            => Ok(await service.CreatePhoneAsync(newPhone));

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePhoneAsync(
            [FromRoute] Guid id,
            UpdatePhoneDto phone)
                => Ok(await service.UpdatePhoneAsync(id, phone));

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePhoneAsync([FromRoute] Guid id)
            => Ok(await service.DeletePhoneAsync(id));
    }
}
