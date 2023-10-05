using AutoMapper;
using SocialNetwork.Entities.Concrete;
using SocialNetwork.Entities.DTOs.CommentDTO;
using SocialNetwork.Entities.DTOs.PostDTO;
using SocialNetwork.Entities.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRegisterDTO,User>().ReverseMap();
            CreateMap<PostShareDTO,Post>().ReverseMap();
            CreateMap<CommentCreateDTO, Comment>().ReverseMap();
            CreateMap<Comment,CommentUserDTO>().ReverseMap();
            //post-dto first
            //get-class first

        }
    }
}
