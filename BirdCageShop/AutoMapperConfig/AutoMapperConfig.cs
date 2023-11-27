using AutoMapper;
using BirdCageShop.BusinessLogic.AutoMapperModule;
namespace BirdCageShop.Presentation.AutoMapperConfig
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.ConfigEquipmentModule();
                mc.ConfigOrderDetailModule();
                mc.ConfigOrderModule();
                mc.ConfigPaymentModule();
                mc.ConfigProductEquipmentModule();
                mc.ConfigProductModule();
                mc.ConfigRoleModule();
                mc.ConfigUserModule();
                mc.ConfigVoucherModule();
                mc.ConfigNotificationModule();      
                mc.ConfigBirdTypeCategoryModule();
                mc.ConfigReviewModule();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
