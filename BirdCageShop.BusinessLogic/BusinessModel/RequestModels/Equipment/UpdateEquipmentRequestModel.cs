


namespace Ecommerce.BusinessLogic.RequestModels.Equipment 
{

   public class UpdateEquipmentRequestModel {

        public string EquipmentId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? Charge { get; set; }
    }

}
