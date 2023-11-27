

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IProductRepository :IBaseRepository<Product>
    {
    }
    public partial class ProductRepository :BaseRepository<Product>, IProductRepository
    {
         public ProductRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


