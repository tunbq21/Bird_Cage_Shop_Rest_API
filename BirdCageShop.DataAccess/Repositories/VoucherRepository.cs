

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IVoucherRepository :IBaseRepository<Voucher>
    {
    }
    public partial class VoucherRepository :BaseRepository<Voucher>, IVoucherRepository
    {
         public VoucherRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


