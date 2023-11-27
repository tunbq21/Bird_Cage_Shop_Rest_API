

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class OrderViewModel {
        public string OrderId { get; set; } = null!;
        public string? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public int? OrderStatus { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Voucher { get; set; }
        public string? Country { get; set; }
        public string? Method { get; set; }
        public string? Comment { get; set; }
        public string? AssignedEmp { get; set; }
        public string UserName { get; set; }
    }

}
