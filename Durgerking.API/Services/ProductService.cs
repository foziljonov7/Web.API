using Durgerking.API.Data;
using Durgerking.API.Dtos;
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

        public async Task<Product> CreateProduct(CreateProductDto newProduct)
        {
            var product = new Product
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                Quantity = newProduct.Quantity,
                Description = newProduct.Description,
                Created = DateTime.UtcNow.AddHours(5)
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

        public async Task<Product> UpdateProduct(int id, UpdateProductDto product)
        {
            var updated = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);


            if (updated is null)
                return null;

            updated.Name = product.Name;
            updated.Price = product.Price;
            updated.Description = product.Description;
            updated.Quantity = product.Quantity;
            updated.Updated = DateTime.UtcNow.AddHours(5);

            await _dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
