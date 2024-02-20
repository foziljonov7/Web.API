using System.ComponentModel.DataAnnotations;

namespace Mobile.API.Entity
{
    public class Phone
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MinLength(3)]
        public string Brand { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Made { get; set; }
        [Required]
        public string Imei { get; set; }
    }
}
