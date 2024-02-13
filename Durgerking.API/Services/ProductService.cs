using Durgerking.API.Models;

namespace Durgerking.API.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Gamburger",
                Price = 25000,
                Description = "Mazali va yoqimli zararli fast foodlar"
            }
        };
        public async Task<Product> CreateProduct(Product newProduct)
        {
            var product = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description
            };

            products.Add(product);
            return await Task.FromResult(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProduct(id);

            products.Remove(product);
            return true;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = products.Find(p => p.Id == id);

            if (product is null)
                return null;

            return await Task.FromResult(product);
        }

        public async Task<List<Product>> GetProducts()
            => await Task.FromResult(products);
    }
}
