

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IProductEquipmentRepository :IBaseRepository<ProductEquipment>
    {
    }
    public partial class ProductEquipmentRepository :BaseRepository<ProductEquipment>, IProductEquipmentRepository
    {
         public ProductEquipmentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


