
using AutoMapper;
using BirdCageShop.BusinessLogic.BusinessModel.RequestModels.Notification;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Equipment;
using Ecommerce.BusinessLogic.ViewModels;



namespace BirdCageShop.BusinessLogic.Services
{
    public interface INotificationService
    {
        public List<NotificationViewModel> GetByUserId(string idTmp);
        public NotificationViewModel CreateNotification(CreateNotificationRequestModel notificationCreate);
        public bool DeleteNotification(string idTmp);
    }
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public NotificationService(INotificationRepository notificationRepository,IMapper mapper ) {
            _notificationRepository = notificationRepository;
            _mapper = mapper;

        }
        public NotificationViewModel CreateNotification(CreateNotificationRequestModel notificationCreate)
        {
            var notification = _mapper.Map<Notification>(notificationCreate);
            notification.NotificationId = Guid.NewGuid().ToString();

            _notificationRepository.Create(notification);
            _notificationRepository.Save();

            return _mapper.Map<NotificationViewModel>(notification);
        }
        public bool DeleteNotification(string idTmp)
        {
            var notification = _notificationRepository.Get().SingleOrDefault(x => x.NotificationId.Equals(idTmp));
            if (notification == null) return false;
            _notificationRepository.Delete(notification);
            _notificationRepository.Save();

            return true;
        }

        public List<NotificationViewModel> GetByUserId(string idTmp)
        {
            var notifications = _notificationRepository.Get().Where(x => x.UserId.Equals(idTmp) ).ToList();
            if (notifications == null) return null;

            return _mapper.Map<List<NotificationViewModel>>(notifications);
        }
    }
}
