using System.Linq.Expressions;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Repository
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategory();

        Task<IEnumerable<Product>> GetCategoryAndFeatures(bool tracking = true,
            params Expression<Func<Product, object>>[] includes);
    }
}
