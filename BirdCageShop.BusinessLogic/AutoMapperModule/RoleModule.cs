
using AutoMapper;

using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Role;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class RoleModule
    {
        public static void ConfigRoleModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Role, RoleViewModel>().ReverseMap();
            mc.CreateMap<Role, CreateRoleRequestModel>().ReverseMap();
            mc.CreateMap<Role, UpdateRoleRequestModel>().ReverseMap();
        }
    }

}
