using Cars.API.Data;
using Cars.API.Dtos;
using Cars.API.Entities;
using Cars.API.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cars.API.Services
{
    public class CarServices : ICarServices
    {
        private readonly AppDbContext _dbContext;
        private TimeSpan difference;
        public CarServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppDbContext DbContext => _dbContext;

        public async Task<GeneralResponse> CreateCarAsync(CreateCarDto newCar)
        {
            var car = new Car
            {
                Model = newCar.Model,
                Price = newCar.Price,
                Probeg = newCar.Probeg,
                Color = newCar.Color,
                Engine = newCar.Engine,
                Status = Status.Active
            };

            if (car is null)
                return new GeneralResponse(false, "Is null");

            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();

            return new GeneralResponse(true, "Successfully created");
        }

        public async Task<GeneralResponse> DeleteCarAsync(Guid id)
        {
            var product = await _dbContext.Cars
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) 
                return new GeneralResponse(false, "Is null");

            _dbContext.Cars .Remove(product);
            _dbContext.SaveChanges();
            return new GeneralResponse(true, "Successfully deleted");
        }

        public async Task<Car> GetCarAsync(Guid id)
        {
            var car = await _dbContext.Cars
                .FirstOrDefaultAsync(p => p.Id == id);

            if (car is null) 
                return null;

            var difference = DateTime.UtcNow.AddHours(5) - car.Created;

            if (difference.TotalDays <= 365 && car.Probeg < 10000)
                car.Status = Status.New;

            if (car.Probeg > 10000 && car.Probeg < 100000)
                car.Status = Status.InGood;

            if (car.Probeg > 100000)
                car.Status = Status.InBad;

            await _dbContext.SaveChangesAsync();

            return car;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            var cars = await _dbContext.Cars
                .Include(c => c.Category)
                .ToListAsync();

            if (cars is null)
                return null;

            foreach (var car in cars)
            {
                var difference = DateTime.UtcNow.AddHours(5) - car.Created;

                if (difference.TotalDays <= 365 && car.Probeg < 10000)
                    car.Status = Status.New;

                if (car.Probeg > 10000 && car.Probeg < 100000)
                    car.Status = Status.InGood;

                if (car.Probeg > 100000)
                    car.Status = Status.InBad;
            }

            await _dbContext.SaveChangesAsync();

            return cars;
        }

        public async Task<GeneralResponse> UpdateCarAsync(Guid id, UpdateCarDto newCar)
        {
            var update = await _dbContext.Cars
                .FirstOrDefaultAsync(p => p.Id == id);

            if (update is null)
                return new GeneralResponse(false, "Is null");

            update.Model = newCar.Model;
            update.Price = newCar.Price;
            update.Probeg = newCar.Probeg;
            update.Color = newCar.Color;
            update.Engine = newCar.Engine;

            await _dbContext.SaveChangesAsync();
            return new GeneralResponse(true, "Successfully updated");
        }
    }
}
