using AutoMapper;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BurakSekmen.API.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CouponsController :CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICouponService _couponService;

        public CouponsController(IMapper mapper, ICouponService couponService)
        {
            _mapper = mapper;
            _couponService = couponService;
        }
        [HttpGet]   
        public async Task<IActionResult> GetAll()
        {
            var coupons = await _couponService.GetAllAsync();
            var couponDto = _mapper.Map<List<CouponDto>>(coupons.ToList());
            return CreateActionResult(CustomeResponseDto<List<CouponDto>>.Success(couponDto, 200));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coupon = await _couponService.GetByIdAsync(id);
            var couponDto = _mapper.Map<CouponDto>(coupon);
            return CreateActionResult(CustomeResponseDto<CouponDto>.Success(couponDto, 200));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CouponDto couponDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            couponDto.recordingname = username!;
            var coupon = await _couponService.AddAsync(_mapper.Map<Coupon>(couponDto));

            return CreateActionResult(CustomeResponseDto<CouponDto>.Success(_mapper.Map<CouponDto>(coupon), 200));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CouponDto couponDto)
        {
            await _couponService.UpdateAsync(_mapper.Map<Coupon>(couponDto));
            return CreateActionResult(CustomeResponseDto<CouponDto>.Success(_mapper.Map<CouponDto>(couponDto), 200));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coupon = await _couponService.GetByIdAsync(id);
            await _couponService.RemoveAsync(coupon);
            return CreateActionResult(CustomeResponseDto<CouponDto>.Success(_mapper.Map<CouponDto>(coupon), 200));
        }
    }
}
