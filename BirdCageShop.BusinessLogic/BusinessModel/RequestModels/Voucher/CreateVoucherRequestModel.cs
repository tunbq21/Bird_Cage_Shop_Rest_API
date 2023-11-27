

namespace Ecommerce.BusinessLogic.RequestModels.Voucher 
{

   public class CreateVoucherRequestModel {
   
        public int? Point { get; set; }
        public string? Discount { get; set; }
        public string? CouponCode { get; set; }
        public DateTime? ExpirationDate { get; set; }

    }

}
