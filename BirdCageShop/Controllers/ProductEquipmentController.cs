
using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.ProductEquipment;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/productequipments")]
    public class ProductEquipmentController : ControllerBase {

        private IProductEquipmentService _productequipmentService;

         public ProductEquipmentController(IProductEquipmentService productequipmentService)
        {
            _productequipmentService = productequipmentService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<ProductEquipmentViewModel> CreateProductEquipment(CreateProductEquipmentRequestModel productequipmentCreate)
        {
            var productequipmentCreated = _productequipmentService.CreateProductEquipment(productequipmentCreate);

            if (productequipmentCreated == null)
            {
                return NotFound("");
            }
            return productequipmentCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<ProductEquipmentViewModel>> GetAll()
        {
            var productequipmentList = _productequipmentService.GetAll();

            if (productequipmentList == null)
            {
                return NotFound("");
            }
            return productequipmentList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<ProductEquipmentViewModel> GetById(string idTmp)
        {
            var productequipmentDetail = _productequipmentService.GetById(idTmp);

            if (productequipmentDetail == null)
            {
                return NotFound("");
            }
            return productequipmentDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteProductEquipment(string idTmp)
        {
            var check = _productequipmentService.DeleteProductEquipment(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<ProductEquipmentViewModel> UpdateProductEquipment(UpdateProductEquipmentRequestModel productequipmentCreate)
        {
            var productequipmentUpdated = _productequipmentService.UpdateProductEquipment(productequipmentCreate);

            if (productequipmentUpdated == null)
            {
                return NotFound("");
            }
            return productequipmentUpdated;
        }
    }

}
