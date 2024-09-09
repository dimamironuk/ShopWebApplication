using AutoMapper;
using Core.Dtos;
using Core.Dtos.CategoryDtos;
using Core.Dtos.ProductDtos;
using Data.Entities;

namespace YouTube.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<EditProductDto, Product>().ReverseMap();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<EditCategorytDto, Category>();
        }
    }
}
