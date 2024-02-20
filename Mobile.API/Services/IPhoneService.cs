using Mobile.API.Dtos;
using Mobile.API.Entity;

namespace Mobile.API.Services
{
    public interface IPhoneService
    {
        Task<List<Phone>> GetPhonesAsync();
        Task<Phone> GetPhoneAsync(Guid id);
        Task<Phone> CreatePhoneAsync(CreatePhoneDto newPhone);
        Task<Phone> UpdatePhoneAsync(Guid id, UpdatePhoneDto phone);
        Task<bool> DeletePhoneAsync(Guid id);
        Task<(double totalPrice, int quantity)> SalesPhoneAsync(Guid id, int quantity);
    }
}
