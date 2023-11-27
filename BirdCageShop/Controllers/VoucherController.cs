

using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Voucher;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/vouchers")]
    public class VoucherController : ControllerBase {

        private IVoucherService _voucherService;

         public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<VoucherViewModel> CreateVoucher(CreateVoucherRequestModel voucherCreate)
        {
            var voucherCreated = _voucherService.CreateVoucher(voucherCreate);

            if (voucherCreated == null)
            {
                return NotFound("");
            }
            return voucherCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<VoucherViewModel>> GetAll()
        {
            var voucherList = _voucherService.GetAll();

            if (voucherList == null)
            {
                return NotFound("");
            }
            return voucherList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<VoucherViewModel> GetById(string idTmp)
        {
            var voucherDetail = _voucherService.GetById(idTmp);

            if (voucherDetail == null)
            {
                return NotFound("");
            }
            return voucherDetail;
        }

        [MapToApiVersion("1")]
        [HttpGet("userId")]
        public ActionResult<List<VoucherViewModel>> GetByUserId(string userId)
        {
            var voucherDetail = _voucherService.GetByUserId(userId);

            if (voucherDetail == null)
            {
                return NotFound("");
            }
            return voucherDetail;
        }

        [MapToApiVersion("1")]
        [HttpGet("productId")]
        public ActionResult<List<VoucherViewModel>> GetByProductId(string productId)
        {
            var voucherDetail = _voucherService.GetByProductId(productId);

            if (voucherDetail == null)
            {
                return NotFound("");
            }
            return voucherDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteVoucher(string idTmp)
        {
            var check = _voucherService.DeleteVoucher(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<VoucherViewModel> UpdateVoucher(UpdateVoucherRequestModel voucherCreate)
        {
            var voucherUpdated = _voucherService.UpdateVoucher(voucherCreate);

            if (voucherUpdated == null)
            {
                return NotFound("");
            }
            return voucherUpdated;
        }

       
       
    }

}
