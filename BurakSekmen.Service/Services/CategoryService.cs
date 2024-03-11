using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using BurakSekmen.Core.Services;
using BurakSekmen.Core.UnitOfWorks;

namespace BurakSekmen.Service.Services
{
    public class CategoryService:Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> genericRepository, IUnitOfWorks unitOfWorks, ICategoryRepository categoryRepository, IMapper mapper) : base(genericRepository, unitOfWorks)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomeResponseDto<CategoryWithProductsDto>> GetSingleCategoryByWithProductAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByWithProductAsync(categoryId);
            if (category == null)
            {
                return CustomeResponseDto<CategoryWithProductsDto>.Fail($"{categoryId} For Category Not Found", 404);
            }
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
            return CustomeResponseDto<CategoryWithProductsDto>.Success(categoryDto, 200);
        }
    }
}
