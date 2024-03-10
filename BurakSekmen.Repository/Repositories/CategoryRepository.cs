using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Repository.Context;

namespace BurakSekmen.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}

