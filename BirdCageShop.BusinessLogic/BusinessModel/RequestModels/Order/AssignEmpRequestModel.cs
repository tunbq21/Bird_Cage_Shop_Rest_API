namespace Ecommerce.BusinessLogic.RequestModels.Order
{
    public class AssignEmpRequestModel
    {
        public string OrderId { get; set; } = null!;
        public string? UserId { get; set; }
    }
}
