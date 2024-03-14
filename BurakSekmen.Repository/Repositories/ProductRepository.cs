using System.Linq.Expressions;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BurakSekmen.Repository.Repositories
{
    public class ProductRepository :GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            // Eager Loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetCategoryAndFeatures(bool tracking = true, params Expression<Func<Product, object>>[] includes)
        {
            IQueryable<Product> query = _context.Products;

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var data = await query.ToListAsync();

            if (data == null || !data.Any())
            {
                throw new Exception("Ürünler Bulunamadı");
            }

            return data;
        }
    }
}
