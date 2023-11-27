

namespace Ecommerce.BusinessLogic.RequestModels.OrderDetail 
{

   public class UpdateOrderDetailRequestModel {
        public string OrderDetailId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string? ProductId { get; set; }
        public int? Quantity { get; set; }
    }

}
