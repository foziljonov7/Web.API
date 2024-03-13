using Cars.API.Data;
using Cars.API.Dtos;
using Cars.API.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Cars.API.Validations;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration.GetConnectionString("localhost");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connectionStrings));

//Services
builder.Services.AddScoped<ICarServices, CarServices>();

//Validators
builder.Services.AddTransient<IValidator<CreateCarDto>, CreateCarValidation>();
builder.Services.AddTransient<IValidator<UpdateCarDto>, UpdateCarValidation>();

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
