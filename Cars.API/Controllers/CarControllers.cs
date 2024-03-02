using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarControllers : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Hello()
        {
            return Ok("Welcome to Car API");
        }
    }
}
