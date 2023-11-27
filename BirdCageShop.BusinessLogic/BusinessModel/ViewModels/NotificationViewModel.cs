
namespace Ecommerce.BusinessLogic.ViewModels
{
    public class NotificationViewModel
    {
        public string NotificationId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? Body { get; set; }
        public int? NotificationType { get; set; }
        public DateTime? SentTime { get; set; }
        public int? Status { get; set; }

    }
}
