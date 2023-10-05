using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Core.Utilities.Result.Concrete.SuccessResult;
using SocialNetwork.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Concrete
{
    public class ReactionManager : IReactionService
    {
        private readonly IReactionDAL _reactionDAL;

        public ReactionManager(IReactionDAL reactionDAL)
        {
            _reactionDAL = reactionDAL;
        }

        public IResult DisLikePost(int userId, int postId)
        {
            _reactionDAL.DisLikePost(userId, postId);
            return new SuccessResult();

        }

        public IResult LikePost(int userId, int postId)
        {
            _reactionDAL.LikePost(userId, postId);
            return new SuccessResult();
        }
    }
}