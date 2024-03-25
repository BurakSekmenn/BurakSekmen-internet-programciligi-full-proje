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
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>(); 
            CreateMap<ProductFeature, ProductFeatureAndProductinfoDtos>();
            CreateMap<ProductDto, ProductFeature>();
            CreateMap<ProductFeatureAndProductinfoDtos, ProductDto>();
            CreateMap<ProductFeatureAndProductinfoDtos, ProductDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
            CreateMap<SaveProductDto, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.ProductFeatureId, opt => opt.MapFrom(src => src.ProductFeatureId))
                .ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Customer,CustomerDto>().ReverseMap(); 
            CreateMap<CustomerDto,Customer>().ReverseMap(); 
            CreateMap<Tax, TaxDto>().ReverseMap();// tax ve taxdto arasında mapleme yapar


        }
    }
}
