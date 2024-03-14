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
    }
}
