

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class PaymentViewModel {
        public string PaymentId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Cvv { get; set; }
    }

}
