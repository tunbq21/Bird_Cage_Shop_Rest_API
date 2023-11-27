
using AutoMapper;

using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Voucher;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class VoucherModule
    {
        public static void ConfigVoucherModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Voucher, VoucherViewModel>().ReverseMap();
            mc.CreateMap<Voucher, CreateVoucherRequestModel>().ReverseMap();
            mc.CreateMap<Voucher, UpdateVoucherRequestModel>().ReverseMap();
        }
    }

}
