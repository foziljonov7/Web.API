using System.ComponentModel.DataAnnotations;

namespace Mobile.API.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}
