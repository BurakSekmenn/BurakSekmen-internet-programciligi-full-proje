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
                return BadRequest(_responseService.HandleError(errors.ToString()));
            }

            var result = await _userService.RegisterAsync(register);
            if (result == null) // Kayıt işlemi başarısızsa
            {
                return BadRequest(_responseService.HandleError(result));
            }

            return Ok(_responseService.HandleSuccess("Kullanıcı Başarıyla Eklendi!"));
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(Token model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }

     
    }
}
