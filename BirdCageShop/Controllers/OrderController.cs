

using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Order;
using Ecommerce.BusinessLogic.RequestModels.OrderDetail;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/orders")]
    public class OrderController : ControllerBase {

        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<OrderViewModel> CreateOrder(CreateOrderRequestModel orderCreate)
        {
            try {
                var orderCreated = _orderService.CreateOrder(orderCreate);

                if (orderCreated == null)
                {
                    return NotFound("Fail to Create Order");
                }
                return orderCreated;
            }
            catch (Exception ex) { return NotFound(ex.Message); }
          
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<OrderViewModel>> GetAll()
        {
            var orderList = _orderService.GetAll();

            if (orderList == null)
            {
                return NotFound("Orders Not Found");
            }
            return orderList;
        }

        [MapToApiVersion("1")]
        [HttpGet("orderId")]
        public ActionResult<OrderViewModel> GetById(string idTmp)
        {
            var orderDetail = _orderService.GetById(idTmp);

            if (orderDetail == null)
            {
                return NotFound("Order Not Found");
            }
            return orderDetail;
        }
        [MapToApiVersion("1")]
        [HttpGet("userId")]
        public ActionResult<List<OrderViewModel>> GetByUserId(string idTmp)
        {
            var orderDetail = _orderService.GetByUserId(idTmp);

            if (orderDetail == null)
            {
                return NotFound("Order Not Found");
            }
            return orderDetail;
        }
        [MapToApiVersion("1")]
        [HttpGet("empId")]
        public ActionResult<List<OrderViewModel>> GetOrderByEmpId(string idTmp)
        {
            var orderDetail = _orderService.GetOrderByEmpId(idTmp);

            if (orderDetail == null)
            {
                return NotFound("Order Not Found");
            }
            return orderDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteOrder(string idTmp)
        {
            var check = _orderService.DeleteOrder(idTmp);

            if (check == false)
            {
                return NotFound("Fail To Delete Order");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<OrderViewModel> UpdateOrder(UpdateOrderRequestModel orderCreate)
        {
            try {  
                var orderUpdated = _orderService.UpdateOrder(orderCreate);

                if (orderUpdated == null)
                {
                    return NotFound("Fail To Update Order");
                }
                return orderUpdated;
            }catch (Exception ex) { return NotFound(ex.Message); }
           
        }
        [MapToApiVersion("1")]
        [HttpPut("orderId")]
        public ActionResult<OrderViewModel> UpdateOrderById(UpdateOrderByIdRequestModel orderStatusUpdate)
        {
            try { 
                var orderUpdated = _orderService.UpdateOrderById(orderStatusUpdate);

                if (orderUpdated == null)
                {
                    return NotFound("Fail To Update Order");
                }
                return orderUpdated; 
            } catch (Exception ex) { return NotFound(ex.Message); }
           
        }
        [MapToApiVersion("1")]
        [HttpPut("orderId/assigned-employee")]
        public ActionResult<OrderViewModel> AssignEmployee(AssignEmpRequestModel assignEmpRequest)
        {

            var assignEmp = _orderService.AssignEmployee(assignEmpRequest);
            if(assignEmp == null)
            {
                return NotFound("Cannot Assign this employee");
            }
            return assignEmp;
        }
    }

}
