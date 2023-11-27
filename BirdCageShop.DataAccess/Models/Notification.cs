using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class Notification
    {
        public string NotificationId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? Body { get; set; }
        public int? NotificationType { get; set; }
        public DateTime? SentTime { get; set; }
        public int? Status { get; set; }

        public virtual User? User { get; set; }
    }
}
