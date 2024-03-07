using Cars.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarControllers : ControllerBase
    {
        private readonly ICarServices services;

        public CarControllers(ICarServices services)
            => this.services = services;

        [HttpGet("/")]
        public async Task<IActionResult> GetCarsAsync()
            => Ok(await services.GetCarsAsync());
    }
}
