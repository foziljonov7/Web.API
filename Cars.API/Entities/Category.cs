namespace Cars.API.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}
