using AutoMapper;
using Cars.API.Entities;
using Cars.API.ViewModels;

namespace Cars.API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<SoldViewModel, SoldViewModel>();
        }
    }
}
