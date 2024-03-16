using Cars.API.Data;
using Cars.API.Entities;
using Cars.API.Response;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbcontext;

        public CategoryRepository(AppDbContext dbcontext)
        {
             dbcontext = dbcontext;
        }

        public async Task<GeneralResponse> CreateCategoryAsync(string name)
        {
            if (name is null) 
                return new GeneralResponse(false, "name is null");

            var category = new Category
            {
                Name = name
            };

            await  dbcontext.Categories.AddAsync(category);
            await  dbcontext.SaveChangesAsync();
            return new GeneralResponse(true, "Successfully created");
        }

        public async Task<List<Category>> GetCategoriesAsync()
            => await  dbcontext.Categories.ToListAsync();

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await dbcontext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is null)
                return null;

            return category;
        }

        public async Task<List<Car>> GetCategoryByCarAsync(int categoryId)
        {
            var category = await dbcontext.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            return null;
        }
    }
}
