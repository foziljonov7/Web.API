using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Todo.API.Dtos;
using Todo.API.Services;
using Todo.API.Validators;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService service;
        private readonly IValidator<CreatedTodoDtos> createValidator;
        private readonly IValidator<UpdateTodoDto> updateValidator;

        public TodoController(
            ITodoService service,
            IValidator<CreatedTodoDtos> createValidator,
            IValidator<UpdateTodoDto> updateValidator)
        {
            this.service = service;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
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
                var validationResult = await createValidator.ValidateAsync(newTodo);

                if(!validationResult.IsValid)
                    return Ok(validationResult.Errors);

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
            var validationResult = await updateValidator.ValidateAsync(todo);
            if (!validationResult.IsValid)
                return Ok(validationResult.Errors);

            var response = await service.UpdateTodoAsync(id, todo);
            return Ok(response);
        }

        [HttpDelete("Deleted/{id}")]
        public async Task<IActionResult> DeleteTodoAsync([FromRoute] Guid id)
            => Ok(await service.DeleteTodoAsync(id));
    }
}
