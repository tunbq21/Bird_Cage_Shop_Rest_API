
using AutoMapper;
using BirdCageShop.BusinessLogic.BusinessModel.RequestModels.User;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class UserModule
    {
        public static void ConfigUserModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<User, UserViewModel>().ReverseMap();
            mc.CreateMap<User, CreateUserRequestModel>().ReverseMap();
            mc.CreateMap<User, UpdateUserRequestModel>().ReverseMap();
            mc.CreateMap<User, LoginViewModel>().ReverseMap();
            mc.CreateMap<User, RegisterRequestModel>().ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore()).ReverseMap();
                
        }
    }

}
