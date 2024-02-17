using Durgerking.API.Dtos;
using Durgerking.API.Models;

namespace Durgerking.API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> CreateProduct(CreateProductDto newProduct);
        Task<bool> DeleteProduct(int id);
        Task<Product> UpdateProduct(int id, UpdateProductDto product);
    }
}
