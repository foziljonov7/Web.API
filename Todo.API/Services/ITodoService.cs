using Todo.API.Dtos;
using Todo.API.Entity;
using Todo.API.Response;

namespace Todo.API.Services
{
    public interface ITodoService
    {
        Task<List<TodoModel>> GetTodosAsync();
        Task<TodoModel> GetTodoAsync(Guid id);
        Task<GeneralResponse> CreateTodoAsync(CreatedTodoDtos newTodo);
        Task<GeneralResponse> UpdateTodoAsync(Guid id, UpdateTodoDto update);
        Task<GeneralResponse> DeleteTodoAsync(Guid id);
    }
}
