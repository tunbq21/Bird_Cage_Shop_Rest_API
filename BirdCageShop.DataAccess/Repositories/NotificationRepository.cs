

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories
{

    public partial interface INotificationRepository : IBaseRepository<Notification>
    {
    }
    public partial class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}


