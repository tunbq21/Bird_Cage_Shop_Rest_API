using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Notifications = new HashSet<Notification>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            Vouchers = new HashSet<Voucher>();
        }

        public string UserId { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? BannedTime { get; set; }
        public string? Image { get; set; }
        public string? Token { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
