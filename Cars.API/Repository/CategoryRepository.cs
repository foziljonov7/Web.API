using Cars.API.Data;
using Cars.API.Entities;
using Cars.API.Response;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cars.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbcontext;
        private object name;

        public CategoryRepository(AppDbContext context)
        {
            _dbcontext = context;
        }

        public object Name { get; private set; }

        public async Task<GeneralResponse> CreateCategoryAsync(string name)
        {
            if (name is null)
                return new GeneralResponse(false, "Name is null");

            var category = new Category();
            {
                Name = name;
            };
            
            await _dbcontext.Categories.AddAsync(category);
            await _dbcontext.SaveChangesAsync();
            return new GeneralResponse(true, "Successfully created");
        }

        public async Task<List<Category>> GetCategoriesAsync()
         => await _dbcontext.Categories.ToListAsync();

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _dbcontext.Categories
                .FirstOrDefaultAsync(p => p.Id == id);

            if (category is null)
                throw new InvalidOperationException($"Category with Id: {id} not found");

            return category;
        }

        public async Task<List<Car>> GetCategoryByCarAsync(int categoryId)
        {
            var category = await _dbcontext.Cars
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();

            if (category is null)
                throw new InvalidOperationException($"Category not found");

            return category;
        }
    }
}
