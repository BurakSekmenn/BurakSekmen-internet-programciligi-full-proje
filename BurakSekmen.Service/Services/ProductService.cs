using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;

namespace BurakSekmen.Service.Services
{
    public class ProductService: Service<Product>,IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IUnitOfWorks unitOfWork, IMapper mapper) : base(productRepository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomeResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomeResponseDto<List<ProductWithCategoryDto>>.Success(productWithCategoryDto, 200);
        }
    }
}
