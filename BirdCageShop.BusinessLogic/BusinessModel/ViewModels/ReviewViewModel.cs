

namespace Ecommerce.BusinessLogic.ViewModels
{
    public class ReviewViewModel
    {
        public string ReviewId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Image { get; set; }
        public string? ProductId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int? HasPurchased { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
