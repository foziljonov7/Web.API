using Cars.API.Dtos;
using Cars.API.Entities;

namespace Cars.API.Services
{
    public interface ICarServices
    {
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(Guid id);
        Task<Car> CreateCarAsync(CreateCarDto newCar);
        Task<Car> UpdateCarAsync(Guid id, UpdateCarDto newCar);
        Task<bool> DeleteCarAsync(Guid id);
    }
}