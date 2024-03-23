using Cars.API.Entities;

namespace Cars.API.ViewModels
{
    public class SoldViewModel
    {
        public Guid Id { get; set; }   
        public Guid CarId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime SoldDate { get; set; }

        public static explicit operator SoldViewModel(Sold sold)
        {
            return new SoldViewModel
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
