using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities.DTOs.UserDTO;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            var result=_userService.Register(userRegisterDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

                
        }
    }
}
