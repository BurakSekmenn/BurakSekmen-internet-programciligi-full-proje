using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;

namespace BurakSekmen.Service.Services
{
    public class ProductFeatureService:Service<ProductFeature>,IProductFeatureService
    {
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly IMapper _mapper;
        public ProductFeatureService(IGenericRepository<ProductFeature> genericRepository, IUnitOfWorks unitOfWorks, IMapper mapper, IProductFeatureRepository productFeatureRepository) : base(genericRepository, unitOfWorks)
        {
           
            _mapper = mapper;
            _productFeatureRepository = productFeatureRepository;
        }


        public async Task<CustomeResponseDto<List<ProductFeatureAndProductinfoDtos>>> GetProductFeaturesWithProducts(int productId)
        {
            var productdata = await _productFeatureRepository.GetProductFeaturesWithProducts(productId);
            if (productdata == null || !productdata.Any())
            {
                return CustomeResponseDto<List<ProductFeatureAndProductinfoDtos>>.Fail($"Ürüne ait bilgi bulunamadı", 404);
            }

            var categoryDtoList = productdata.Select(pf => new ProductFeatureAndProductinfoDtos
            {
                ProductFeatures = _mapper.Map<List<ProductFeatureDto>>(pf),
                Product = _mapper.Map<ProductDto>(pf.Product)
            }).ToList();



            return CustomeResponseDto<List<ProductFeatureAndProductinfoDtos>>.Success(categoryDtoList,200);
        }

       
    }
}
