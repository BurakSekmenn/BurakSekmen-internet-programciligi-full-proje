using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.API.Controllers
{
    [Authorize]
    public class SalesController : CustomBaseController
    {
        private readonly ISalesService _salesService;
        private readonly IPersonService _personService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public SalesController(ISalesService salesService, IMapper mapper, IPersonService personService, ICategoryService categoryService)
        {
            _salesService = salesService;
            _mapper = mapper;
            _personService = personService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _salesService.GetAllAsync();
            var salesDtos = _mapper.Map<List<SalesDto>>(sales.ToList());
            return CreateActionResult(CustomeResponseDto<List<SalesDto>>.Success(salesDtos, 200));
        }

        [HttpGet("ListPersonSales")]
        public async Task<IActionResult> ListPersonSales()
        {
            var personSales = await _salesService.ListPersonSales(false, i => i.Product, m => m.Person);
            return Ok(personSales);
        }

        [HttpGet("ListPersonSales/{id}")]
        public async Task<IActionResult> ListPersonSales(int id)
        {
            var personSales = await _salesService.GetPersonSalesWithIncludesAsync(
              id,
              tracking: false, 
              includes: s => s.Product 
          );
            return Ok(personSales);
        }

    

        [HttpPost]
        public async Task<IActionResult> Save(SalesDto salesDto)
        {
            var person = await _personService.AnyAsync(person => person.Id == salesDto.PersonId);
            var product = await _categoryService.AnyAsync(product => product.Id == salesDto.ProductId);
            if (!person || !product)
            {
                string errorMessage = "";
                if (!person)
                {
                    errorMessage += $"{salesDto.PersonId} Böyle Bir Id Sahip Personel Yoktur.  ";
                }
                if (!product)
                {
                    errorMessage += $"{salesDto.PersonId} Böyle Bir Id Sahip Personel Yoktur.  ";
                }
                return NotFound(new { ErrorMessages = errorMessage });
            }
            var result = await _salesService.MakeSale(salesDto.ProductId, salesDto.Quantity);
            if (!result)
            {
                return BadRequest(new { ErrorMessages = "Stok Yetersiz" });
            }
            var sales = _mapper.Map<Sales>(salesDto);
            var newSales = await _salesService.AddAsync(sales);
            return CreateActionResult(CustomeResponseDto<SalesDto>.Success(_mapper.Map<SalesDto>(newSales), 200));
        }
    }
}
