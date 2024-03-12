using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>();
            //    "Unable to cast object of type 'BurakSekmen.Core.DTOs.ProductDto' to type 'BurakSekmen.Core.DTOs.ProductFeatureAndProductinfoDtos'."
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>(); 
            CreateMap<ProductFeature, ProductFeatureAndProductinfoDtos>();
            CreateMap<ProductDto, ProductFeature>();
            CreateMap<ProductFeatureAndProductinfoDtos, ProductDto>();
            CreateMap<ProductFeatureAndProductinfoDtos, ProductDto>().ReverseMap();

        }
    }
}
