using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace BurakSekmen.Repository.Repositories
{
    public class ProductFeatureRepository:GenericRepository<ProductFeature>,IProductFeatureRepository
    {
        public ProductFeatureRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<List<ProductFeatureAndProductinfoDtos>> GetProductFeaturesWithProducts(int productId)
        {
            
            var data = await _context.ProductFeatures
                .Include(pf => pf.Product)
                .Where(x => x.ProductId == productId)
                .ToListAsync();


            return  null;

        }
    }
}
