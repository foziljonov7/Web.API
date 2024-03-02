using Microsoft.EntityFrameworkCore;
using Todo.API.Data;
using Todo.API.Dtos;
using Todo.API.Entity;
using Todo.API.Response;

namespace Todo.API.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext dbContext;

        public TodoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<GeneralResponse> CreateTodoAsync(CreatedTodoDtos newTodo)
        {
            var todo = new TodoModel
            {
                Id = Guid.NewGuid(),
                Title = newTodo.Title,
                Description = newTodo.Description,
                Created = DateTime.UtcNow.AddHours(5)
            };

            await dbContext.Todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return new GeneralResponse(true, "Successfully created");
        }

        public async Task<GeneralResponse> DeleteTodoAsync(Guid id)
        {
            var todo = await dbContext.Todos
                .FirstOrDefaultAsync(t => t.Id == id);

            if (todo is null)
                return new GeneralResponse(false, "Todo is not found");

            dbContext.Todos.Remove(todo);
            await dbContext.SaveChangesAsync();

            return new GeneralResponse(true, "Successfully deleted");
        }

        public async Task<TodoModel> GetTodoAsync(Guid id)
        {
            var todo = await dbContext.Todos
                .FirstOrDefaultAsync(t => t.Id == id);

            if (todo is null)
                return null;

            return todo;
        }

        public async Task<List<TodoModel>> GetTodosAsync()
            => await dbContext.Todos.ToListAsync();

        public async Task<GeneralResponse> UpdateTodoAsync(Guid id, UpdateTodoDto update)
        {
            var todo = await dbContext.Todos
                .FirstOrDefaultAsync(t => t.Id == id);

            if (todo is null)
                return new GeneralResponse(false, "Todo is not found");

            todo.Title = update.Title;
            todo.Description = update.Description;
            todo.Updated = DateTime.UtcNow.AddHours(5);

            await dbContext.SaveChangesAsync();
            return new GeneralResponse(true, "Successfully saved");
        }
    }
}
