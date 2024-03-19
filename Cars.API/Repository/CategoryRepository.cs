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

        public async Task<GeneralResponse> CreateCategoryAsync()
        {
            if (name is null)
                return new GeneralResponse(false, "Name is null");

            var category = new Category();
            {
                Name = name;
            };
            
            await _dbcontext.SaveChangesAsync();
            await _dbcontext.Categories.AddAsync(category);
            return new GeneralResponse(true, "Successfully created");
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryRepository repository &&
                   EqualityComparer<AppDbContext>.Default.Equals(_dbcontext, repository._dbcontext);
        }

        public async Task<List<Category>> GetCategories()
         => await _dbcontext.Categories.ToListAsync();

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _dbcontext.Categories
                .FirstOrDefaultAsync(p => p.Id == id);

            if (category is null)
                return null;

            return category;
        }

        public async Task<List<Car>> GetCategoryByCarasync(int categoryId)
        {
            var category = await _dbcontext.Cars
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();

            if (category is null)
                return null;

            return category;
        }
    }
}
