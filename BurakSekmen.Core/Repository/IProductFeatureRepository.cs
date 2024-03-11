using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Repository
{
    public interface IProductFeatureRepository:IGenericRepository<ProductFeature>
    {
        Task<List<ProductFeature>> GetProductFeaturesWithProducts(int productId);
       
    }
}
