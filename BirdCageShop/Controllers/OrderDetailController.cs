
using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/orderdetails")]
    public class OrderDetailController : ControllerBase {

        private IOrderDetailService _orderdetailService;

         public OrderDetailController(IOrderDetailService orderdetailService)
        {
            _orderdetailService = orderdetailService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<List<OrderDetailViewModel>> CreateOrderDetail(List<CreateOrderDetailRequestModel> orderdetailCreate)
        {
            var orderdetailCreated = _orderdetailService.CreateOrderDetail(orderdetailCreate);

            if (orderdetailCreated == null)
            {
                return NotFound("");
            }
            return orderdetailCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<OrderDetailViewModel>> GetAll()
        {
            var orderdetailList = _orderdetailService.GetAll();

            if (orderdetailList == null)
            {
                return NotFound("");
            }
            return orderdetailList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<OrderDetailViewModel> GetById(string idTmp)
        {
            var orderdetailDetail = _orderdetailService.GetById(idTmp);

            if (orderdetailDetail == null)
            {
                return NotFound("");
            }
            return orderdetailDetail;
        }
        [MapToApiVersion("1")]
        [HttpGet("orderId")]
        public ActionResult<List<OrderDetailViewModel>> GetDetailByOrder(string orderId)
        {
            var orderdetailDetail = _orderdetailService.GetDetailByOrder(orderId);

            if (orderdetailDetail == null)
            {
                return NotFound("");
            }
            return orderdetailDetail;
        }
        [MapToApiVersion("1")]
        [HttpGet("userId")]
        public ActionResult<List<OrderDetailViewModel>> GetOrderDetailByUser(string userId)
        {
            var orderdetailDetail = _orderdetailService.GetOrderDetailByUser(userId);

            if (orderdetailDetail == null)
            {
                return NotFound("");
            }
            return orderdetailDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteOrderDetail(string idTmp)
        {
            var check = _orderdetailService.DeleteOrderDetail(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<OrderDetailViewModel> UpdateOrderDetail(UpdateOrderDetailRequestModel orderdetailCreate)
        {
            var orderdetailUpdated = _orderdetailService.UpdateOrderDetail(orderdetailCreate);

            if (orderdetailUpdated == null)
            {
                return NotFound("");
            }
            return orderdetailUpdated;
        }
    }

}
