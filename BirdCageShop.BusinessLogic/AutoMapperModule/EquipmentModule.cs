
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Equipment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class EquipmentModule
    {
        public static void ConfigEquipmentModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Equipment, EquipmentViewModel>().ReverseMap();
            mc.CreateMap<Equipment, CreateEquipmentRequestModel>().ReverseMap();
            mc.CreateMap<Equipment, UpdateEquipmentRequestModel>().ReverseMap();
        }
    }

}
