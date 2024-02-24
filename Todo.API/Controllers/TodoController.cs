using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Todo.API.Dtos;
using Todo.API.Services;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService service;

        public TodoController(ITodoService service)
        {
            this.service = service;
        }
        [HttpGet("/")]
        public async Task<IActionResult> GetTodosAsync()
            => Ok(await service.GetTodosAsync());

        [HttpGet("todo/{id}")]
        public async Task<IActionResult> GetTodoAsync([FromRoute] Guid id)
        {
            var request = await service.GetTodoAsync(id);

            if (request is null)
                return BadRequest("Todo is null");

            return Ok(request);
        }

        [HttpPost("Created")]
        public async Task<IActionResult> CreateTodoAsync(
            [FromBody] CreatedTodoDtos newTodo)
        {
            try
            {
                var request = await service.CreateTodoAsync(newTodo);
                return Ok(request);
            }
            catch(Exception ex)
            {
                return NotFound($"not found: {ex}");
            }
        }

        [HttpPut("Updated/{id}")]
        public async Task<IActionResult> UpdateTodoAsync(
            [FromRoute] Guid id,
            UpdateTodoDto todo)
        {
            return Ok(await service.UpdateTodoAsync(id, todo));
        }

        [HttpDelete("Deleted/{id}")]
        public async Task<IActionResult> DeleteTodoAsync([FromRoute] Guid id)
            => Ok(await service.DeleteTodoAsync(id));
    }
}
