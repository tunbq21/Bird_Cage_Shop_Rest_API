
using AutoMapper;
using Ecommerce.BusinessLogic.ViewModels;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.BusinessLogic.AutoMapperModule
{

    public static class BirdTypeCategoryModule
    {
        public static void ConfigBirdTypeCategoryModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<BirdTypeCategory, BirdTypeCategoryViewModel>().ReverseMap();
           
        }
    }

}
