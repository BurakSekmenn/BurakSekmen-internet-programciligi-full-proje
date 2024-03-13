using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using System.Linq.Expressions;

namespace BurakSekmen.Core.Services
{
    public interface ISalesService:IService<Sales>
    {
        Task<IEnumerable<Sales>> GetPersonSalesWithIncludesAsync(int personId, bool tracking = true,
            params Expression<Func<Sales, object>>[] includes);

        Task<bool> MakeSale(int productId, int quantity);
        Task<bool> UpdateStockAsync(SalesDto salesDto);
    }
}
