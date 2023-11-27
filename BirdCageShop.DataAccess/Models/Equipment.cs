using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            ProductEquipments = new HashSet<ProductEquipment>();
        }

        public string EquipmentId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? Status { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? Charge { get; set; }

        public virtual ICollection<ProductEquipment> ProductEquipments { get; set; }
    }
}
