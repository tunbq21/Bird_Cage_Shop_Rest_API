
using AutoMapper;

using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.ProductEquipment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class ProductEquipmentModule
    {
        public static void ConfigProductEquipmentModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<ProductEquipment, ProductEquipmentViewModel>().ReverseMap();
            mc.CreateMap<ProductEquipment, CreateProductEquipmentRequestModel>().ReverseMap();
            mc.CreateMap<ProductEquipment, UpdateProductEquipmentRequestModel>().ReverseMap();
        }
    }

}
