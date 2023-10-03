using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Entities.DTOs.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Concrete
{
    public class PostManager : IPostService
    {
        public IResult AddPost(int userId, PostShareDTO postShareDTO)
        {
            throw new NotImplementedException();
        }
    }
}
