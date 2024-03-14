using AutoMapper;
using Cars.API.Data;
using Cars.API.Dtos;
using Cars.API.Entities;
using Cars.API.Repository;
using Cars.API.Response;
using Cars.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cars.API.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository repository;
        private readonly IMapper mapper;

        public CarServices(
            ICarRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GeneralResponse> CreateCarAsync(CreateCarDto newCar)
        {
            var response = await repository.CreateCarAsync(newCar);
            return response;
        }

        public async Task<GeneralResponse> DeleteCarAsync(Guid id)
        {
            var response = await repository.DeleteCarAsync(id);
            return response;
        }

        public async Task<CarViewModel> GetCarAsync(Guid id)
        {
            var response = await repository.GetCarAsync(id);
            return (CarViewModel)response;
        }

        public async Task<List<CarViewModel>> GetCarsAsync()
        {
            var response = await repository.GetCarsAsync();
            return mapper.Map<List<Car>, List<CarViewModel>>(response);
        }

        public async Task<GeneralResponse> UpdateCarAsync(Guid id, UpdateCarDto newCar)
        {
            var response = await repository.UpdateCarAsync(id, newCar);
            return response;
        }
    }
}
