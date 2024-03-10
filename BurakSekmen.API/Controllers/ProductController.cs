using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using BurakSekmen.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.API.Controllers
{
 
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;


        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("GetProductWithCategories")]
        public async Task<IActionResult> GetProductWithCategories()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomeResponseDto<List<ProductDto>>.Success(productDto, 200));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomeResponseDto<ProductDto>.Success(productDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomeResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            var productDtos = _mapper.Map<ProductDto>(productDto);
            return Ok(CustomeResponseDto<ProductDto>.Success(productDtos, 204));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.RemoveAsync(product);
            return CreateActionResult(CustomeResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200));
        }

    }


}
