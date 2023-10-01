using AutoMapper;
using SocialNetwork.Entities.Concrete;
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
            CreateMap<User, UserRegisterDTO>().ReverseMap();
        }
    }
}
