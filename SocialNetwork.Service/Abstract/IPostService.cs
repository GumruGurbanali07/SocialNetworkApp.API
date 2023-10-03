using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Entities.DTOs.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Abstract
{
    public interface IPostService
    {
        IResult AddPost(int userId, PostShareDTO postShareDTO);
    }
}
