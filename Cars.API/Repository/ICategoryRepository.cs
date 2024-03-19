using Cars.API.Dtos;
using Cars.API.Entities;
using Cars.API.Response;

namespace Cars.API.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryAsync(int id);
        Task<GeneralResponse> CreateCategoryAsync();
        Task<List<Car>> GetCategoryByCarasync(int categoryId);
    }
}