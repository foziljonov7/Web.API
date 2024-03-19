using Cars.API.Data;
using Cars.API.Dtos;
using Cars.API.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Cars.API.Validations;
using Cars.API.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration.GetConnectionString("localhost");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connectionStrings));

//Services
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarServices, CarServices>();
builder.Services.AddAutoMapper(typeof(Program));

//Validators
builder.Services.AddTransient<IValidator<CreateCarDto>, CreateCarValidation>();
builder.Services.AddTransient<IValidator<UpdateCategoryDto>, UpdateCarValidation>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
