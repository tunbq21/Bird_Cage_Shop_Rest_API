using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class Review
    {
        public string ReviewId { get; set; } = null!;
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int? HasPurchased { get; set; }
        public DateTime? TimeStamp { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
