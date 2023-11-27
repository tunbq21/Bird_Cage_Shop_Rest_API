

namespace Ecommerce.BusinessLogic.RequestModels.Order
{
    public class UpdateOrderByIdRequestModel
    {
        public string OrderId { get; set; } = null!;
        public string? OrderStatus { get; set; }
    }
}
