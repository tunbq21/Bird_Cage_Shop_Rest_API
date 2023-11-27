using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class Payment
    {
        public string PaymentId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Cvv { get; set; }

        public virtual Order PaymentNavigation { get; set; } = null!;
    }
}
