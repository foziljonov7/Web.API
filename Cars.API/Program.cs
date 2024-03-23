using Cars.API.Data;
using Cars.API.Dtos;
using Cars.API.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Cars.API.Validations;
using Cars.API.Repository;
using Cars.API.Helpers;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration.GetConnectionString("localhost");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connectionStrings));

//Repositories
builder.Services.ConfigureRepository();

//Services
builder.Services.ConfigureService();

//Mapper
builder.Services.AddAutoMapper(typeof(Program));

//Validators
builder.Services.ConfigureValidators();

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
