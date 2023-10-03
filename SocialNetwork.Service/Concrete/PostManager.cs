using AutoMapper;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Core.Utilities.Result.Concrete.SuccessResult;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;
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
        private readonly IPostDAL _postDAL;
        private readonly IMapper _mapper;

        public PostManager(IPostDAL postDAL, IMapper mapper = null)
        {
            _postDAL = postDAL;
            _mapper = mapper;
        }

        public IResult AddPost(int userId, PostShareDTO postShareDTO)
        {
            var mapper = _mapper.Map<Post>(postShareDTO);
            mapper.UserId = userId;
            mapper.PostPublishDate = DateTime.Now;
            mapper.PhotoUrl="/";
            mapper.IsActive= true;
            _postDAL.Add(mapper);
            return new SuccessResult();

        }
    }
}
