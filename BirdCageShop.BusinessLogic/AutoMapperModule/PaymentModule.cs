
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Payment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule 
{

   public static class PaymentModule
    {
        public static void ConfigPaymentModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Payment, PaymentViewModel>().ReverseMap();
            mc.CreateMap<Payment, CreatePaymentRequestModel>().ReverseMap();
            mc.CreateMap<Payment, UpdatePaymentRequestModel>().ReverseMap();
        }
    }

}
