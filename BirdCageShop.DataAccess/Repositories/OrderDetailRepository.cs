

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IOrderDetailRepository :IBaseRepository<OrderDetail>
    {
    }
    public partial class OrderDetailRepository :BaseRepository<OrderDetail>, IOrderDetailRepository
    {
         public OrderDetailRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


