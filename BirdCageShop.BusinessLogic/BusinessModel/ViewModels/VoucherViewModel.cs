

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class VoucherViewModel {
        public string VoucherId { get; set; } = null!;
        public int? Point { get; set; }
        public string? Discount { get; set; }
        public string? CouponCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Status { get; set; }
    }

}
