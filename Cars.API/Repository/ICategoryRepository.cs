using Cars.API.Dtos;
using Cars.API.Entities;
using Cars.API.Response;

namespace Cars.API.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<GeneralResponse> CreateCategoryAsync(string name);
        Task<List<Car>> GetCategoryByCarAsync(int categoryId);
    }
}