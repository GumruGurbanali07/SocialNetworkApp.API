using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.DTOs.CommentDTO
{
    public class CommentCreateDTO
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
