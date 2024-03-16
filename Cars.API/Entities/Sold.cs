using System.ComponentModel.DataAnnotations;

namespace Cars.API.Entities
{
    public class Sold
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CarId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
