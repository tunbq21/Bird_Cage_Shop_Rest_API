using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class BirdTypeCategory
    {
        public BirdTypeCategory()
        {
            Products = new HashSet<Product>();
        }

        public int BirdTypeId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
