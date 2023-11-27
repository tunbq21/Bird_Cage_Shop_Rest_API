using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            Products = new HashSet<Product>();
            Users = new HashSet<User>();
        }

        public string VoucherId { get; set; } = null!;
        public int? Point { get; set; }
        public string? Discount { get; set; }
        public string? CouponCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
