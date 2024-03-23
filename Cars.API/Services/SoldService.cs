using AutoMapper;
using Cars.API.Entities;
using Cars.API.Repository;
using Cars.API.Response;
using Cars.API.ViewModels;

namespace Cars.API.Services
{
    public class SoldService : ISoldService
    {
        private readonly ISoldRepository repository;
        private readonly IMapper mapper;

        public SoldService(
            ISoldRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<SoldViewModel> GetSoldAsync(Guid id)
        {
            var response = await repository.GetSoldAsync(id);
            return (SoldViewModel)response;
        }

        public async Task<List<SoldViewModel>> GetSoldsAsync()
        {
            var response = await repository.GetSoldsAsync();
            return mapper.Map<List<Sold>, List<SoldViewModel>>(response);
        }

        public async Task<(GeneralResponse, double totalPrice)> SoldAsync(Guid carId, int quantity)
            => await repository.SoldAsync(carId, quantity);
    }
}
