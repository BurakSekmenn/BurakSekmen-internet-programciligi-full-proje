using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BurakSekmen.Repository.Repositories
{
    public class SalesRepository:GenericRepository<Sales>,ISalesRepository
    {

        public SalesRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Sales>> GetPersonSalesWithIncludesAsync(int personId, bool tracking = true, params Expression<Func<Sales, object>>[] includes)
        {
            IQueryable<Sales> query = _context.Sales.Where(s => s.PersonId == personId);

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var data = await query.ToListAsync();

            if (data == null || data.Count == 0)
            {
                throw new Exception($"{personId} bu personele ait satış bulunamadı.");
            }
            return data;
        }

        public async Task<IEnumerable<Sales>> ListPersonSales(bool tracking = true, params Expression<Func<Sales, object>>[] includes)
        {
            IQueryable<Sales> query = _context.Sales;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var data = await query.ToListAsync();

            return data;
        }

        public async Task<bool> MakeSale(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return false; 
            }
            if (product.Stock < quantity)
            {
                return false; 
            }
            product.Stock -= quantity;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateStockAsync(SalesDto salesDto)
        {
            var product = await _context.Products.FindAsync(salesDto.ProductId);
            if (product == null)
            {
                return false; 
            }

            product.Stock -= salesDto.Quantity;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
