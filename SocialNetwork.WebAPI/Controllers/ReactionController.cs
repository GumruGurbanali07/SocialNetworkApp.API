using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SocialNetwork.Business.Abstract;
using System.IdentityModel.Tokens.Jwt;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _reactionService;

        public ReactionController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }
        [HttpPost("likepost/{postId}")]
        public IActionResult LikePost(int postId)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;

            var result = _reactionService.LikePost(Convert.ToInt32(userId), postId);
            if (result.Success)
            {
                return Ok (result);
                
            }
return BadRequest(result);
        }

        [HttpPost("dislikepost/{postId}")]
        public IActionResult DisLikePost(int postId)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;

            var result = _reactionService.LikePost(Convert.ToInt32(userId), postId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
