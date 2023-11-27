using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductEquipments = new HashSet<ProductEquipment>();
            Reviews = new HashSet<Review>();
            Vouchers = new HashSet<Voucher>();
        }

        public string ProductId { get; set; } = null!;
        public string? ProductName { get; set; }
        public int? BirdTypeId { get; set; }
        public string? Model { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? Size { get; set; }
        public string? ProductMaterial { get; set; }
        public int? BirdCageType { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public decimal? Sale { get; set; }

        public virtual BirdTypeCategory? BirdType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductEquipment> ProductEquipments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
