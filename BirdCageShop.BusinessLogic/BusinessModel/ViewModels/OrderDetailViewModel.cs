

using BirdCageShop.DataAccess.Models;

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class OrderDetailViewModel {
        public string OrderDetailId { get; set; } = null!;
        public string? OrderId { get; set; }
        public string? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }

    }

}
