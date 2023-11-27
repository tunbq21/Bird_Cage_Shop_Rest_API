

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IPaymentRepository :IBaseRepository<Payment>
    {
    }
    public partial class PaymentRepository :BaseRepository<Payment>, IPaymentRepository
    {
         public PaymentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


