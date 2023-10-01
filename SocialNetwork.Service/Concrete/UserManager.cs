using AutoMapper;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Utilities.Business;
using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Core.Utilities.Result.Concrete.ErrorResult;
using SocialNetwork.Core.Utilities.Result.Concrete.SuccessResult;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;
using SocialNetwork.Entities.DTOs.UserDTO;
using SocialNetwork.Core.Security.HashHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities.SharedEmail;
using MassTransit;

namespace SocialNetwork.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserManager(IUserDAL userDAL, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userDAL = userDAL;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public IResult AddFriend(int userId, int friendId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserProfileDTO> GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public IResult Login(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public IResult Register(UserRegisterDTO userRegisterDTO)
        {
            var result=BusinessRules.Check(CheckAge(userRegisterDTO.Birthday),CheckEmail(userRegisterDTO.Email));
            if (!result.Success)
            
                return new SuccessResult();
            
            return new ErrorResult();

            var mapUser = _mapper.Map<User>(userRegisterDTO);
            mapUser.Avatar = "/";
            mapUser.CoverPhoto="/";
            mapUser.EmailToken=Guid.NewGuid().ToString();

            byte[] passwordHash, passwordSalt;
            Hashing.HashPassword(userRegisterDTO.Password, out passwordHash, out passwordSalt);
            mapUser.PasswordSalt = passwordSalt;
            mapUser.PasswordHash = passwordHash;
            mapUser.EmailExpiresDate = DateTime.Now.AddMinutes(5);

            SendEmailCommand sendEmailCommand = new()
            {
                Email = mapUser.Email,
                Name = mapUser.Name,
                Surname = mapUser.Surname,
                Token = mapUser.EmailToken
            };
            _publishEndpoint.Publish<SendEmailCommand>(sendEmailCommand);
            _userDAL.Add(mapUser);
            return new SuccessResult();

        }
        public IResult CheckAge(DateTime birthday)
        {
            var check=DateTime.Now.Year - birthday.Year;
            if (check < 18)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IResult CheckEmail(string email)
        {
            var check=_userDAL.Get(x=>x.Email == email);
            if(check != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult SendEmail()
        {
            throw new NotImplementedException();
        }

        public IResult VerifyEmail(string email, string token)
        {
            throw new NotImplementedException();
        }
    }
}
