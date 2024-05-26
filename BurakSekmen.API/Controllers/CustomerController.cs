using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using BurakSekmen.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.API.Controllers
{
    [Authorize]
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;


        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult(CustomeResponseDto<List<CustomerDto>>.Success(customerDtos, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var newCustomer = await _customerService.AddAsync(_mapper.Map<Customer>(customerDto));
            return CreateActionResult(CustomeResponseDto<CustomerDto>.Success(_mapper.Map<CustomerDto>(newCustomer), 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _customerService.GetByIdAsync(id);
            var personDto = _mapper.Map<CustomerDto>(person);
            return CreateActionResult(CustomeResponseDto<CustomerDto>.Success(personDto, 200));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerDto));
            var customerDtos = _mapper.Map<CustomerDto>(customerDto);
            return Ok(CustomeResponseDto<CustomerDto>.Success(customerDtos, 204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = _customerService.GetByIdAsync(id).Result;
            _customerService.RemoveAsync(customer);
            return CreateActionResult(CustomeResponseDto<CustomerDto>.Success(_mapper.Map<CustomerDto>(customer), 201));
        
        }



    }
}
