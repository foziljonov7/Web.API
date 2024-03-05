using Cars.API.Data;
using Cars.API.Dtos;
using Cars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cars.API.Services
{
    public class CarServices : ICarServices
    {
        private readonly AppDbContext _dbContext;

        public CarServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppDbContext DbContext => _dbContext;

        public async Task<Car> CreateCarAsync(CreateCarDto newCar)
        {
            var car = new Car
            {
                Model = newCar.Model,
                Price = newCar.Price,
                Probeg = newCar.Probeg,
                Color = newCar.Color,
                Engine = newCar.Engine,
            };
            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();

            return car;
        }

        public async Task<bool> DeleteCarAsync(Guid id)
        {
            var product = await _dbContext.Cars
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) 
                return false;

            _dbContext.Cars .Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<Car> GetCarAsync(Guid id)
        {
            var car = await _dbContext.Cars
                .FirstOrDefaultAsync(p => p.Id == id);

            if (car is null) 
                return null;

            return car;
        }

        public async Task<List<Car>> GetCarsAsync()
            => await _dbContext.Cars.ToListAsync();

        public async Task<Car> UpdateCarAsync(Guid id, UpdateCarDto newCar)
        {
            var update = await _dbContext.Cars
                .FirstOrDefaultAsync(p => p.Id == id);

            if (update is null)
                return null;

            update.Model = newCar.Model;
            update.Price = newCar.Price;
            update.Probeg = newCar.Probeg;
            update.Color = newCar.Color;
            update.Engine = newCar.Engine;

            await _dbContext.SaveChangesAsync();
            return update;
        }
    }
}
