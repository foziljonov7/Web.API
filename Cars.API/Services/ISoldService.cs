using Cars.API.Entities;
using Cars.API.Response;
using Cars.API.ViewModels;

namespace Cars.API.Services
{
    public interface ISoldService
    {
        Task<List<SoldViewModel>> GetSoldsAsync();
        Task<SoldViewModel> GetSoldAsync(Guid id);
        Task<(GeneralResponse, double totalPrice)> SoldAsync(Guid carId, int quantity);
    }
}
