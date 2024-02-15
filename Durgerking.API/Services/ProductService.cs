using Durgerking.API.Data;
using Durgerking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Durgerking.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> CreateProduct(Product newProduct)
        {
            var product = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Description = newProduct.Description
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return false;

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return null;

            return product;
        }

        public async Task<List<Product>> GetProducts()
            => await _dbContext.Products.ToListAsync();

        public async Task<Product> UpdateProduct(Product product)
        {
            var updateProduct = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (updateProduct is null)
                return null;

            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Description = product.Description;

            _dbContext.SaveChanges();
            return updateProduct;
        }
    }
}
