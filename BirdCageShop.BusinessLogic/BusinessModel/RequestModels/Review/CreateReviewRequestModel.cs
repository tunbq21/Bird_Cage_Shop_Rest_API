

namespace Ecommerce.BusinessLogic.RequestModels.Review
{

    public class CreateReviewRequestModel
    {
        public string? UserId { get; set; }
        public string ProductId { get; set; } = null!;
        public int? Rating { get; set; }
        public string? Comment { get; set; }
  
    
    }

}
