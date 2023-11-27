
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Product;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class ProductModule
    {
        public static void ConfigProductModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Product, ProductViewModel>().ReverseMap();
            mc.CreateMap<Product, CreateProductRequestModel>().ReverseMap();
            mc.CreateMap<Product, UpdateProductRequestModel>().ReverseMap();
        }
    }

}
