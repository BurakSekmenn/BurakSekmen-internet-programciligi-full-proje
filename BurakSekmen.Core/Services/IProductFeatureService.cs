using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Services
{
    public interface IProductFeatureService:IService<ProductFeature>
    {
        Task<CustomeResponseDto<List<ProductFeatureAndProductinfoDtos>>> GetProductFeaturesWithProducts(int productId);
    
    }
}
