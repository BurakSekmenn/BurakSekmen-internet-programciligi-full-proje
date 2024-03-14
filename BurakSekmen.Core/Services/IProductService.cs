using System.Linq.Expressions;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<CustomeResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
        Task<IEnumerable<Product>> GetCategoryAndFeatures(bool tracking = true,
            params Expression<Func<Product, object>>[] includes);
    }
}
