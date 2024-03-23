using Cars.API.Entities;

namespace Cars.API.ViewModels
{
    public class SoldCarViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime SoldDate { get; set; }

        public static explicit operator SoldCarViewModel(Sold sold)
        {
            return new SoldCarViewModel
            {
                Id = sold.Id,
                CarId = sold.CarId,
                Price = sold.Price,
                Quantity = sold.Quantity,
                TotalPrice = sold.TotalPrice,
                SoldDate = sold.SoldDate
            };
        }
    }
};
