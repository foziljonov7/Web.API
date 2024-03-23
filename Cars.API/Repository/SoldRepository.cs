using Cars.API.Data;
using Cars.API.Entities;
using Cars.API.Response;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Repository
{
    public class SoldRepository : ISoldRepository
    {
        private readonly AppDbContext dbContext;

        public SoldRepository(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<Sold> GetSoldAsync(Guid id)
        {
            var sold = await dbContext.Solds
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sold is null)
                throw new InvalidOperationException($"Sold with Id: {id} not found");

            return sold;
        }

        public async Task<List<Sold>> GetSoldsAsync()
            => await dbContext.Solds.ToListAsync();

        public async Task<(GeneralResponse, double totalPrice)> SoldAsync(Guid carId, int quantity)
        {
            var car = await dbContext.Cars
                .FirstOrDefaultAsync(c => c.Id == carId);

            if (car is null)
                return (new GeneralResponse(false, "Car is null"), 0);

            if (car.Status == Status.SoldOut)
                return (new GeneralResponse(false, "Car sold out"), 0);

            var sold = new Sold
            {
                Id = Guid.NewGuid(),
                CarId = car.Id,
                Quantity = 1,
                Price = car.Price,
                TotalPrice = car.Price * quantity,
                SoldDate = DateTime.UtcNow.AddHours(5)
            };

            var soldCar = car.Status = Status.SoldOut;

            await dbContext.Solds.AddAsync(sold);
            await dbContext.SaveChangesAsync();

            return (new GeneralResponse(true, "The car is sold"), sold.TotalPrice);
        }
    }
}
