

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IRoleRepository :IBaseRepository<Role>
    {
    }
    public partial class RoleRepository :BaseRepository<Role>, IRoleRepository
    {
         public RoleRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


