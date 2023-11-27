
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Review;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BirdCageShop.BusinessLogic.Services
{
    public interface IReviewService
    {
        public ReviewViewModel CreateReview(CreateReviewRequestModel reviewCreate);
        public ReviewViewModel UpdateReview(UpdateReviewRequestModel reviewUpdate);
        public List<ReviewViewModel> GetAll();
        public List<ReviewViewModel> GetByProductId(string productId);
        public bool DeleteReview(string reviewId);



    }
    public class ReviewService : IReviewService
    {
      
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IUserRepository userRepository, IUserService userService)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _userService = userService;
        }

        public ReviewViewModel CreateReview(CreateReviewRequestModel reviewCreate)
        {
            var review = _mapper.Map<Review>(reviewCreate);
            review.ReviewId =Guid.NewGuid().ToString();
            review.TimeStamp = DateTime.Now;

            _reviewRepository.Create(review);
            _reviewRepository.Save();
            return _mapper.Map<ReviewViewModel>(review);
        }

        public List<ReviewViewModel> GetByProductId(string productId)
        {
            var listReview = _reviewRepository.Get().Include(u => u.User).Where(r => r.ProductId.Equals(productId)).ToList();
            if (listReview == null) return null;

            var mappedReviews = _mapper.Map<List<ReviewViewModel>>(listReview);

            // Access user information directly from the Review entity
            foreach (var reviewViewModel in mappedReviews)
            {
                var user = _userService.GetById(reviewViewModel.UserId);

                if (user != null)
                {
                    reviewViewModel.Username = user.Username;
                    reviewViewModel.Image = user.Image;
                }
            }


            return mappedReviews;
        }

        public List<ReviewViewModel> GetAll()
        {
            var listReview = _reviewRepository.Get().ToList();
            if (listReview == null) return null;

            return _mapper.Map<List<ReviewViewModel>>(listReview);
        }

        public ReviewViewModel UpdateReview(UpdateReviewRequestModel reviewUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReview(string reviewId)
        {
            var review = _reviewRepository.Get().SingleOrDefault(o => o.ReviewId.Equals(reviewId));
            if (review == null) return false;

            _reviewRepository.Delete(review);
            _reviewRepository.Save();
            return true;
        }
    }
}
