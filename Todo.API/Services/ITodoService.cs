using Todo.API.Dtos;
using Todo.API.Entity;

namespace Todo.API.Services
{
    public interface ITodoService
    {
        Task<List<TodoModel>> GetTodosAsync();
        Task<TodoModel> GetTodoAsync(Guid id);
        Task<TodoModel> CreateTodoAsync(CreatedTodoDtos newTodo);
        Task<TodoModel> UpdateTodoAsync(Guid id, UpdateTodoDto update);
        Task<bool> DeleteTodoAsync(Guid id);
    }
}
