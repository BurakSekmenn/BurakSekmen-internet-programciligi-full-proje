using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;

namespace BurakSekmen.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        public Task<CustomeResponseDto<CategoryWithProductsDto>> GetSingleCategoryByWithProductAsync(int categoryId);
    }
}
