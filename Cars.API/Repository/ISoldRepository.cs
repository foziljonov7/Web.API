using Cars.API.Entities;
using Cars.API.Response;

namespace Cars.API.Repository
{
    public interface ISoldRepository
    {
        Task<List<Sold>> GetSoldsAsync();
        Task<Sold> GetSoldAsync(Guid id);
        Task<(GeneralResponse, double totalPrice)> SoldAsync(Guid carId, int quantity);
    }
}
