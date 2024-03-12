using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Repository
{
    public interface IProductFeatureRepository:IGenericRepository<ProductFeature>
    {
        Task<List<ProductFeatureAndProductinfoDtos>> GetProductFeaturesWithProducts(int productId);
       
    }
}
