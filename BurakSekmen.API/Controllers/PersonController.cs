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
    public class PersonController : CustomBaseController
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            var personDtos = _mapper.Map<List<PersonDto>>(persons.ToList());
            return CreateActionResult(CustomeResponseDto<List<PersonDto>>.Success(personDtos,200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            var personDto = _mapper.Map<PersonDto>(person);
            return CreateActionResult(CustomeResponseDto<PersonDto>.Success(personDto, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var person = await _personService.AddAsync(_mapper.Map<Person>(personDto));
            return CreateActionResult(CustomeResponseDto<PersonDto>.Success(personDto, 200));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonDto personDto)
        {
            await _personService.UpdateAsync(_mapper.Map<Person>(personDto));
            var persondtos = _mapper.Map<PersonDto>(personDto);
            return CreateActionResult(CustomeResponseDto<PersonDto>.Success(persondtos, 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            await _personService.RemoveAsync(person);
            return CreateActionResult(CustomeResponseDto<PersonDto>.Success(_mapper.Map<PersonDto>(person), 200));
        }

    }
}
