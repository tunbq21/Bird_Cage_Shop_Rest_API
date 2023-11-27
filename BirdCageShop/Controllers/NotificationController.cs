
using BirdCageShop.BusinessLogic.BusinessModel.RequestModels.Notification;
using BirdCageShop.BusinessLogic.Services;
using BirdCageShop.DataAccess.Models;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/notification")]
    public class NotificationController : ControllerBase
    {

        private INotificationService _notificationService;


        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<NotificationViewModel> CreateNotification(CreateNotificationRequestModel notificationCreate)
        {
            var notificaiton = _notificationService.CreateNotification(notificationCreate);
            if(notificaiton == null) return NotFound("");
            return notificaiton;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<List<NotificationViewModel>> GetByUserId(string idTmp)
        {
            var notification = _notificationService.GetByUserId(idTmp);

            if (notification == null)
            {
                return NotFound("");
            }
            return notification;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteNotification(string idTmp)
        {
            var check = _notificationService.DeleteNotification(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

      
    }

}
