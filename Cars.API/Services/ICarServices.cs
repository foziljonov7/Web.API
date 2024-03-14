using Cars.API.Dtos;
using Cars.API.Entities;
using Cars.API.Response;
using Cars.API.ViewModels;

namespace Cars.API.Services
{
    public interface ICarServices
    {
        Task<List<CarViewModel>> GetCarsAsync();
        Task<CarViewModel> GetCarAsync(Guid id);
        Task<GeneralResponse> CreateCarAsync(CreateCarDto newCar);
        Task<GeneralResponse> UpdateCarAsync(Guid id, UpdateCarDto newCar);
        Task<GeneralResponse> DeleteCarAsync(Guid id);
    }
}