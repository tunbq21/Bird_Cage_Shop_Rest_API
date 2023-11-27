

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories
{

    public partial interface IBirdTypeCategoryRepository: IBaseRepository<BirdTypeCategory>
    {
    }
    public partial class BirdTypeCategoryRepository : BaseRepository<BirdTypeCategory>, IBirdTypeCategoryRepository
    {
        public BirdTypeCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}


