using Cars.API.Entities;
using Cars.API.Response;

namespace Cars.API.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<List<Car>> GetCategoryByCarAsync(int categoryId);
        Task<GeneralResponse> CreateCategoryAsync(string name);
    }
}
