using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Business.AutoMapper;
using SocialNetwork.Business.Concrete;
using SocialNetwork.Core.Configuration;
using SocialNetwork.Core.Utilities.EMailHelper;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Concrete.EntityFramework;

namespace SocialNetwork.Business.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void Create(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IUserService,UserManager> ();
            services.AddScoped<IUserDAL, EFUserDAL>();
            services.AddTransient<IMailHelper, MailHelper>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MapperProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
