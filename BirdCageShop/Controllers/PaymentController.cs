

using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Payment;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/payments")]
    public class PaymentController : ControllerBase {

        private IPaymentService _paymentService;

         public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<PaymentViewModel> CreatePayment(CreatePaymentRequestModel paymentCreate)
        {
            var paymentCreated = _paymentService.CreatePayment(paymentCreate);

            if (paymentCreated == null)
            {
                return NotFound("");
            }
            return paymentCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<PaymentViewModel>> GetAll()
        {
            var paymentList = _paymentService.GetAll();

            if (paymentList == null)
            {
                return NotFound("");
            }
            return paymentList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<PaymentViewModel> GetById(string idTmp)
        {
            var paymentDetail = _paymentService.GetById(idTmp);

            if (paymentDetail == null)
            {
                return NotFound("");
            }
            return paymentDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeletePayment(string idTmp)
        {
            var check = _paymentService.DeletePayment(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<PaymentViewModel> UpdatePayment(UpdatePaymentRequestModel paymentCreate)
        {
            var paymentUpdated = _paymentService.UpdatePayment(paymentCreate);

            if (paymentUpdated == null)
            {
                return NotFound("");
            }
            return paymentUpdated;
        }
    }

}
