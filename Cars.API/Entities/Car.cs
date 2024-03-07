using System.ComponentModel.DataAnnotations;

namespace Cars.API.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Model { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Probeg { get; set; }
        public string Color { get; set; }
        [Required]
        public string Engine { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Status Status { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
