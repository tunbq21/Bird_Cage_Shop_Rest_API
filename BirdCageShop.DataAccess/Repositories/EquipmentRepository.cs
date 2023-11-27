

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IEquipmentRepository :IBaseRepository<Equipment>
    {
    }
    public partial class EquipmentRepository :BaseRepository<Equipment>, IEquipmentRepository
    {
         public EquipmentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


