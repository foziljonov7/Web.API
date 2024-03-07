namespace Cars.API.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Probeg { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
