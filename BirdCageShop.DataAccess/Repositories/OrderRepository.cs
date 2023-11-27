

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IOrderRepository :IBaseRepository<Order>
    {
    }
    public partial class OrderRepository :BaseRepository<Order>, IOrderRepository
    {
         public OrderRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


