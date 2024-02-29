using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Todo.API.Data;
using Todo.API.Dtos;
using Todo.API.Services;
using Todo.API.Validators;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration.GetConnectionString("localhost");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connectionStrings));

//Services
builder.Services.AddScoped<ITodoService, TodoService>();

//Validators
builder.Services.AddTransient<IValidator<CreatedTodoDtos>, CreateTodoValidation>();
builder.Services.AddTransient<IValidator<UpdateTodoDto>, UpdateTodoValidation>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
