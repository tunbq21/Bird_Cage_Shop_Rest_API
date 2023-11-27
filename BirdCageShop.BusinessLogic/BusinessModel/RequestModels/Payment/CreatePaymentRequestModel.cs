

namespace Ecommerce.BusinessLogic.RequestModels.Payment 
{

   public class CreatePaymentRequestModel {
   
        public string? PaymentMethod { get; set; }
        public string? OrderId { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Cvv { get; set; }
    }

}
