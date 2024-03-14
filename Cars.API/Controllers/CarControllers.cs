using Cars.API.Dtos;
using Cars.API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarControllers : ControllerBase
    {
        private readonly ICarServices services;
        private readonly IValidator<CreateCarDto> createValidator;
        private readonly IValidator<UpdateCarDto> updateValidator;

        public CarControllers(
            ICarServices services,
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
    }
}
