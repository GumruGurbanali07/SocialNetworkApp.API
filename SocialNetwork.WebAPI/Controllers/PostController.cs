using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities.DTOs.PostDTO;
using System.IdentityModel.Tokens.Jwt;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("sharepost")]
        public IActionResult SharePost([FromBody] PostShareDTO postShareDTO)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
           
            int.TryParse(userId, out int convertingUserId);
            var result = _postService.AddPost(convertingUserId, postShareDTO);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
