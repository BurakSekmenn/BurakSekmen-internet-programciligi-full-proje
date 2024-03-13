using System.Linq.Expressions;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Repository
{
    public interface ISalesRepository:IGenericRepository<Sales>
    {
        Task<IEnumerable<Sales>> GetPersonSalesWithIncludesAsync(int personId, bool tracking = true,
            params Expression<Func<Sales, object>>[] includes);
        Task<bool> MakeSale(int productId, int quantity);
        Task<bool> UpdateStockAsync(SalesDto salesDto);
    }

}
