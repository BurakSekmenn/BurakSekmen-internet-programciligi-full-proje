using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BurakSekmen.API.Controllers
{
    [AllowAnonymous]
    public class TaxController : CustomBaseController
    {
        private readonly ITaxService _taxService;
        private readonly IMapper _mapper;
        public TaxController(ITaxService taxService, IMapper mapper)
        {
            _taxService = taxService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var tax = await _taxService.GetAllAsync();
             var taxdto = _mapper.Map<List<TaxDto>>(tax.ToList());
             return CreateActionResult(CustomeResponseDto<List<TaxDto>>.Success(taxdto,200));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tax = await _taxService.GetByIdAsync(id);
            var taxdto = _mapper.Map<TaxDto>(tax);
            return CreateActionResult(CustomeResponseDto<TaxDto>.Success(taxdto,200));
        }
        [HttpPost]
        public async Task<IActionResult> Save(TaxDto taxDto)
        {
            var tax = await _taxService.AddAsync(_mapper.Map<Tax>(taxDto));
            return CreateActionResult(CustomeResponseDto<TaxDto>.Success(taxDto,200));
        }
        [HttpPut]
        public IActionResult Update(TaxDto taxDto)
        {
            var tax = _taxService.UpdateAsync(_mapper.Map<Tax>(taxDto));
            return CreateActionResult(CustomeResponseDto<TaxDto>.Success(taxDto,200));
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
           var tax = _taxService.GetByIdAsync(id).Result;
            _taxService.RemoveAsync(tax);
            return CreateActionResult(CustomeResponseDto<TaxDto>.Success(_mapper.Map<TaxDto>(tax),200));
        }
    }
}
