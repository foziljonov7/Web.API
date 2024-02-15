using Durgerking.API.Models;

namespace Durgerking.API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> CreateProduct(Product newProduct);
        Task<bool> DeleteProduct(int id);
        Task<Product> UpdateProduct(Product product);
    }
}
