

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IUserRepository :IBaseRepository<User>
    {
    }
    public partial class UserRepository :BaseRepository<User>, IUserRepository
    {
         public UserRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


