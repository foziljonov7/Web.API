namespace Cars.API.Dtos
{
    public class UpdateCarDto
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public string Probeg { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public int CategoryId { get; set; }
    }
}
