using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Repository
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategory();
    }
}
