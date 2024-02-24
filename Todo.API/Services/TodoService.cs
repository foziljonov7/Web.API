using Microsoft.EntityFrameworkCore;
using Todo.API.Data;
using Todo.API.Dtos;
using Todo.API.Entity;

namespace Todo.API.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext dbContext;

        public TodoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TodoModel> CreateTodoAsync(CreatedTodoDtos newTodo)
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

            return todo;
        }

        public async Task<bool> DeleteTodoAsync(Guid id)
        {
            var todo = await dbContext.Todos
                .FirstOrDefaultAsync(t => t.Id == id);

            if (todo is null)
                return false;

            dbContext.Todos.Remove(todo);
            await dbContext.SaveChangesAsync();

            return true;
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

        public async Task<TodoModel> UpdateTodoAsync(Guid id, UpdateTodoDto update)
        {
            var todo = await dbContext.Todos
                .FirstOrDefaultAsync(t => t.Id == id);

            if (todo is null)
                return null;

            todo.Title = update.Title;
            todo.Description = update.Description;
            todo.Updated = DateTime.UtcNow.AddHours(5);

            await dbContext.SaveChangesAsync();
            return todo;
        }
    }
}
