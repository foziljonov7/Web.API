namespace Durgerking.API.Models
{
    public class Product
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
