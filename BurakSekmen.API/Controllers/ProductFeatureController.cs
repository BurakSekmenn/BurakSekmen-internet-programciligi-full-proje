using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BurakSekmen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController : CustomBaseController
    {
        private readonly IProductFeatureService _productFeatureService;
        private readonly IMapper _mapper;

        public ProductFeatureController(IProductFeatureService productFeatureService, IMapper mapper)
        {
            _productFeatureService = productFeatureService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductFeatureDto productFeatureDto)
        {
            var productFeature = await _productFeatureService.AddAsync(_mapper.Map<ProductFeature>(productFeatureDto));
            return CreateActionResult(CustomeResponseDto<ProductFeatureDto>.Success(_mapper.Map<ProductFeatureDto>(productFeature), 200));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var productFeature = _productFeatureService.GetByIdAsync(id).Result;
            await _productFeatureService.RemoveAsync(productFeature);
            return CreateActionResult(CustomeResponseDto<PersonDto>.Success(_mapper.Map<PersonDto>(productFeature), 200));
        }
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductFeatures(int productId)
        {
            var productFeatures = await _productFeatureService.GetByIdIncludeAsync(productId, false, i => i.Product);
            return Ok(productFeatures);
        }

    }
}
