using Cars.API.Dtos;
using Cars.API.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarControllers : ControllerBase
    {
        private readonly ICarRepository services;
        private readonly IValidator<CreateCarDto> createValidator;
        private readonly IValidator<UpdateCarDto> updateValidator;

        public CarControllers(
            ICarRepository services,
            IValidator<CreateCarDto> createValidator,
            IValidator<UpdateCarDto> updateValidator)
        {
            this.updateValidator = updateValidator;
            this.createValidator = createValidator;
            this.services = services;
        }

        [HttpGet("/")]
        public async Task<IActionResult> GetCarsAsync()
            => Ok(await services.GetCarsAsync());

        [HttpGet("Car/{id}")]
        public async Task<IActionResult> GetCarAsync([FromRoute] Guid id)
            => Ok(await services.GetCarAsync(id));

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCarAsync([FromBody] CreateCarDto newDto)
        {
            var validationResult = await createValidator.ValidateAsync(newDto);

            if (!validationResult.IsValid)
                return Ok(validationResult.Errors);

            return Ok(await services.CreateCarAsync(newDto));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCarAsync(
            [FromRoute] Guid id,
            UpdateCarDto dto)
        {
            var validationResult = await updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return Ok(validationResult.Errors);

            return Ok(await services.UpdateCarAsync(id, dto));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCarAsync([FromRoute] Guid id)
            => Ok(await services.DeleteCarAsync(id));
    }
}
