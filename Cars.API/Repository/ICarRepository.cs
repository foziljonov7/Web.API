using Cars.API.Dtos;
using Cars.API.Entities;
using Cars.API.Response;

namespace Cars.API.Repository
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(Guid id);
        Task<GeneralResponse> CreateCarAsync(CreateCarDto newCar);
        Task<GeneralResponse> UpdateCarAsync(Guid id, UpdateCarDto newCar);
        Task<GeneralResponse> DeleteCarAsync(Guid id);
    }
}
