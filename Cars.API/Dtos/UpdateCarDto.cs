namespace Cars.API.Dtos
{
    public class UpdateCategoryDto
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public double Probeg { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public int CategoryId { get; set; }
    }
}
