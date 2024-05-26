using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BurakSekmen.API.Controllers
{
    [Authorize]
    public class ProductFeatureController : CustomBaseController
    {
        private readonly IProductFeatureService _productFeatureService;
        private readonly IMapper _mapper;

        public ProductFeatureController(IProductFeatureService productFeatureService, IMapper mapper)
        {
            _productFeatureService = productFeatureService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _productFeatureService.GetAllAsync();
            var productfeaturedtos = _mapper.Map<List<ProductFeatureDto>>(persons.ToList());
            return CreateActionResult(CustomeResponseDto<List<ProductFeatureDto>>.Success(productfeaturedtos, 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _productFeatureService.GetByIdAsync(id);
            var productfeaturedto = _mapper.Map<ProductFeatureDto>(person);
            return CreateActionResult(CustomeResponseDto<ProductFeatureDto>.Success(productfeaturedto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductFeatureDto productfeaturedto)
        {
            var person = await _productFeatureService.AddAsync(_mapper.Map<ProductFeature>(productfeaturedto));
            return CreateActionResult(CustomeResponseDto<ProductFeatureDto>.Success(productfeaturedto, 200));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductFeatureDto productfeaturedto)
        {
            await _productFeatureService.UpdateAsync(_mapper.Map<ProductFeature>(productfeaturedto));
            var productfeaturedtos = _mapper.Map<ProductFeatureDto>(productfeaturedto);
            return CreateActionResult(CustomeResponseDto<ProductFeatureDto>.Success(productfeaturedtos, 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productfeaturedtos = _productFeatureService.GetByIdAsync(id).Result;
            await _productFeatureService.RemoveAsync(productfeaturedtos);
            return CreateActionResult(CustomeResponseDto<ProductFeatureDto>.Success(_mapper.Map<ProductFeatureDto>(productfeaturedtos), 200));
        }


    }
}
