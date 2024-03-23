using AutoMapper;
using Cars.API.Entities;
using Cars.API.Repository;
using Cars.API.Response;
using Cars.API.ViewModels;

namespace Cars.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        private readonly IMapper mapper;

        public CategoryService(
            ICategoryRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GeneralResponse> CreateCategoryAsync(string name)
        {
            var response = await repository.CreateCategoryAsync(name);
            return response;
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            var response = await repository.GetCategoriesAsync();
            return mapper.Map<List<Category>, List<CategoryViewModel>>(response);
        }

        public async Task<CategoryViewModel> GetCategoryAsync(int id)
        {
            var response = await repository.GetCategoryAsync(id);
            return (CategoryViewModel)response;
        }

        public async Task<List<CarViewModel>> GetCategoryByCarAsync(int categoryId)
        {
            var response = await repository.GetCategoryByCarAsync(categoryId);
            return mapper.Map<List<Car>, List<CarViewModel>>(response);
        }
    }
}
