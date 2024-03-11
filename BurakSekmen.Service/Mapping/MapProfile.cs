using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
       
            CreateMap<ProductFeature, ProductFeatureAndProductinfoDtos>();
            CreateMap<ProductFeature, ProductFeatureAndProductinfoDtos>();
            CreateMap<Product, ProductFeatureAndProductinfoDtos>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();


        }
    }
}
