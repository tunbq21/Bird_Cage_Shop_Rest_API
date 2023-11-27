
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Review;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.AutoMapperModule
{

    public static class ReviewModule
    {
        public static void ConfigReviewModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Review, ReviewViewModel>().ReverseMap();
            mc.CreateMap<Review, CreateReviewRequestModel>().ReverseMap();
            mc.CreateMap<Review, UpdateReviewRequestModel>().ReverseMap();


        }
    }

}
