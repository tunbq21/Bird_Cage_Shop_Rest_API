

namespace Ecommerce.BusinessLogic.RequestModels.ProductEquipment 
{

   public class UpdateProductEquipmentRequestModel {
        public string ProductEquipmentId { get; set; } = null!;
        public string? ProductId { get; set; }
        public string? EquipmentId { get; set; }
    }

}
