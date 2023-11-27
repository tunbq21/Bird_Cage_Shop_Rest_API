

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class EquipmentViewModel {

        public string EquipmentId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? Status { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? Charge { get; set; }
    }

}
