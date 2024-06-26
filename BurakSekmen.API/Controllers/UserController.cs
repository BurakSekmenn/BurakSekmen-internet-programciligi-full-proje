﻿using Azure;
using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IResponseService _responseService;

        public Response Response { get; set; }
        public UserController(IUserService userService, IResponseService responseService)
        {
            _userService = userService;
            _responseService = responseService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> ResultAsync(RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(_responseService.HandleError(string.Join(", ", errors)));
            }

            var result = await _userService.RegisterAsync(register);
            if (result.StartsWith("User Registered"))
            {
                return Ok(_responseService.HandleSuccess("Kullanıcı başarıyla eklendi!"));
            }
            else
            {
                return BadRequest(new { errors = new List<string> { result } });
            }
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(Token model)
        {
            var result = await _userService.GetTokenAsync(model);
            if (result == null  || !result.IsAuthenticated)
            {
                return BadRequest(_responseService.HandleError("Kullanıcı Adı veya Şifre Hatalı!"));
            }
            return Ok(_responseService.HandleSuccessData("Giriş Başarılı", result));
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }

     
    }
}
