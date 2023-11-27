using AutoMapper;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.ViewModels;


namespace BirdCageShop.BusinessLogic.AutoMapperModule
{
    public static class NotificationModule
    {
        public static void ConfigNotificationModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Notification, NotificationViewModel>().ReverseMap();
           
        }
    }
}
