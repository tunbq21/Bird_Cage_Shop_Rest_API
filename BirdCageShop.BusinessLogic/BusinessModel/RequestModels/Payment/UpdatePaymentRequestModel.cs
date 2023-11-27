

namespace Ecommerce.BusinessLogic.RequestModels.Payment 
{

   public class UpdatePaymentRequestModel {
        public string PaymentId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Cvv { get; set; }
    }

}
