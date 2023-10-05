using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Entities.DTOs.CommentDTO;
using System.IdentityModel.Tokens.Jwt;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost("addcomment")]
        public IActionResult AddComment([FromBody] CommentCreateDTO commentCreateDTO)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;

            var result = _commentService.AddComment(Convert.ToInt32(userId), commentCreateDTO);
            if(result.Success) { 
            return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
