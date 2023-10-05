using AutoMapper;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Core.Utilities.Result.Concrete.SuccessResult;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;
using SocialNetwork.Entities.DTOs.CommentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDAL _commentDAL;
        private readonly IMapper _mapper;

        public CommentManager(ICommentDAL commentDAL, IMapper mapper)
        {
            _commentDAL = commentDAL;
            _mapper = mapper;
        }

        public IResult AddComment(int userId, CommentCreateDTO commentCreateDTO)
        {
            var mapper= _mapper.Map<Comment>(commentCreateDTO);
            mapper.UserId = userId;
            _commentDAL.Add(mapper);
            return new SuccessResult();
        }
    }
}
