using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Repository
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByWithProductAsync(int categoryId);
    }
}
