using Cars.API.Dtos;
using Cars.API.Repository;
using Cars.API.Services;
using Cars.API.Validations;
using FluentValidation;

namespace Cars.API.Helpers
{
    public static class ServiceConfiguration
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISoldRepository, SoldRepository>();
        }

        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<ICarServices, CarServices>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISoldService, SoldService>();
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateCarDto>, CreateCarValidation>();
            services.AddTransient<IValidator<UpdateCarDto>, UpdateCarValidation>();
        }
    }
}
