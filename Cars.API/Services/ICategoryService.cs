using Cars.API.Response;
using Cars.API.ViewModels;

namespace Cars.API.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategoriesAsync();
        Task<CategoryViewModel> GetCategoryAsync(int id);
        Task<GeneralResponse> CreateCategoryAsync(string name);
        Task<List<CarViewModel>> GetCategoryByCarAsync(int categoryId);
    }
}
