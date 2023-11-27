

namespace BirdCageShop.BusinessLogic.BusinessModel.RequestModels.Notification
{
    public class CreateNotificationRequestModel
    {
        public string? UserId { get; set; }
        public string? Body { get; set; }
        public int? NotificationType { get; set; }
        
    }
}
