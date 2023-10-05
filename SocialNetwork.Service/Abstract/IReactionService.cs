using SocialNetwork.Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Abstract
{
    public interface IReactionService
    {
        IResult LikePost(int userId, int postId);
        IResult DisLikePost(int userId, int postId);
    }
}
