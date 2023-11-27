
using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Equipment;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/equipments")]
    public class EquipmentController : ControllerBase {

        private IEquipmentService _equipmentService;

         public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<EquipmentViewModel> CreateEquipment(CreateEquipmentRequestModel equipmentCreate)
        {
            var equipmentCreated = _equipmentService.CreateEquipment(equipmentCreate);

            if (equipmentCreated == null)
            {
                return NotFound("");
            }
            return equipmentCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<EquipmentViewModel>> GetAll()
        {
            var equipmentList = _equipmentService.GetAll();

            if (equipmentList == null)
            {
                return NotFound("");
            }
            return equipmentList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<EquipmentViewModel> GetById(string idTmp)
        {
            var equipmentDetail = _equipmentService.GetById(idTmp);

            if (equipmentDetail == null)
            {
                return NotFound("");
            }
            return equipmentDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteEquipment(string idTmp)
        {
            var check = _equipmentService.DeleteEquipment(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<EquipmentViewModel> UpdateEquipment(UpdateEquipmentRequestModel equipmentCreate)
        {
            var equipmentUpdated = _equipmentService.UpdateEquipment(equipmentCreate);

            if (equipmentUpdated == null)
            {
                return NotFound("");
            }
            return equipmentUpdated;
        }
    }

}
