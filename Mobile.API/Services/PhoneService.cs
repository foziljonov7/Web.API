using Microsoft.EntityFrameworkCore;
using Mobile.API.Data;
using Mobile.API.Dtos;
using Mobile.API.Entity;

namespace Mobile.API.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly AppDbContext dbContext;

        public PhoneService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Phone> CreatePhoneAsync(CreatePhoneDto newPhone)
        {
            var phone = new Phone
            {
                Id = Guid.NewGuid(),
                Brand = newPhone.Brand,
                Description = newPhone.Description,
                Price = newPhone.Price,
                Quantity = newPhone.Quantity,
                Made = newPhone.Made,
                Imei = newPhone.Imei
            };

            await dbContext.Phones.AddAsync(phone);
            await dbContext.SaveChangesAsync();

            return phone;
        }

        public async Task<bool> DeletePhoneAsync(Guid id)
        {
            var phone = await dbContext.Phones
                .FirstOrDefaultAsync(p => p.Id == id);

            if (phone is null)
                return false;

            dbContext.Phones.Remove(phone);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Phone> GetPhoneAsync(Guid id)
        {
            var phone = await dbContext.Phones
                .FirstOrDefaultAsync(p => p.Id == id);

            if (phone is null)
                return null;

            return phone;
        }

        public async Task<List<Phone>> GetPhonesAsync()
            => await dbContext.Phones.ToListAsync();

        public async Task<(double totalPrice, int quantity)> SalesPhoneAsync(Guid id, int quantity)
        {
            var phone = await dbContext.Phones
                .FirstOrDefaultAsync(p => p.Id == id);

            if (phone is null)
                return (totalPrice: 0, quantity: 0);

            if(phone.Quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero");

            if(phone.Quantity < quantity)
                throw new InvalidOperationException("Insufficient quantity in stock");

            phone.Quantity -= quantity;

            double totalPrice = phone.Price * quantity;

            await dbContext.SaveChangesAsync();
            return (totalPrice: totalPrice, quantity: quantity);
        }

        public async Task<Phone> UpdatePhoneAsync(Guid id, UpdatePhoneDto phone)
        {
            var updated = await dbContext.Phones
                .FirstOrDefaultAsync(p => p.Id == id);

            if (updated is null)
                return null;

            updated.Brand = phone.Brand;
            updated.Description = phone.Description;
            updated.Price = phone.Price;
            updated.Quantity = phone.Quantity;
            updated.Made = phone.Made;
            updated.Imei = phone.Imei;

            await dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
