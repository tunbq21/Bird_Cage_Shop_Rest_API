

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories
{

    public partial interface IReviewRepository : IBaseRepository<Review>
    {
    }
    public partial class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}


