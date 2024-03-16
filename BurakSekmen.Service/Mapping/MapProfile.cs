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
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.productFeature, opt => opt.MapFrom(src => src.productFeature));
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>(); 
            CreateMap<ProductFeature, ProductFeatureAndProductinfoDtos>();
            CreateMap<ProductDto, ProductFeature>();
            CreateMap<ProductFeatureAndProductinfoDtos, ProductDto>();
            CreateMap<ProductFeatureAndProductinfoDtos, ProductDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
          

        }
    }
}
