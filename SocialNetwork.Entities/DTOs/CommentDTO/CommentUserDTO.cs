using SocialNetwork.Entities.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.DTOs.CommentDTO
{
    public class CommentUserDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserPostDTO UserPostDTO { get; set; }
    }
}
