using Cars.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Cars.API.ViewModels
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public double Probeg { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public CategoryViewModel Category { get; set; }
        public Status Status { get; set; }



        public static explicit operator CarViewModel(Car car)
        {
            if (car is null)
                return null;

            return new CarViewModel
            {
                Id = car.Id,
                Model = car.Model,
                Price = car.Price,
                Probeg = car.Probeg,
                Color = car.Color,
                Engine = car.Engine,
                Created = car.Created,
                Updated = car.Updated,
                Category = (CategoryViewModel)car.Category,
                Status = car.Status
            };
        }
    }
}
