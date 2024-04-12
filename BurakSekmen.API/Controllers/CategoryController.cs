using System.Security.Claims;
using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.API.Controllers
{
    [Authorize]
    
    public class CategoryController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
 
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByWithProductAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByWithProductAsync(categoryId));
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomeResponseDto<List<CategoryDto>>.Success(categoryDto, 200));
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomeResponseDto<CategoryDto>.Success(categoryDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            categoryDto.RecordingName = username;
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomeResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDto));
            var categoryDtos = _mapper.Map<CategoryDto>(categoryDto);
            return Ok(CustomeResponseDto<CategoryDto>.Success(categoryDtos, 204));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.RemoveAsync(category);
            return CreateActionResult(CustomeResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 201));
        }

    }
}
