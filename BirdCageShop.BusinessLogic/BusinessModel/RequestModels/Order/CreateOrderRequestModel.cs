

using Ecommerce.BusinessLogic.RequestModels.OrderDetail;

namespace Ecommerce.BusinessLogic.RequestModels.Order 
{

   public class CreateOrderRequestModel {
        public string? UserId { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Voucher { get; set; }
        public string? Country { get; set; }
        public string? Method { get; set; }
        public string? Comment { get; set; }
        public List<CreateOrderDetailRequestModel> orderDetail { get; set; }
  

    }

}
