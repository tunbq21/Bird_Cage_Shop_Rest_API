
using Ecommerce.BusinessLogic.ViewModels;
using BirdCageShop.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/birdtype")]
    public class BirdTypeCategoryController : ControllerBase
    {

        private IBirdTypeCategoryService _birdTypeService;

        public BirdTypeCategoryController(IBirdTypeCategoryService birdTypeCategoryService)
        {
            _birdTypeService = birdTypeCategoryService;
        }

      

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<BirdTypeCategoryViewModel>> GetAll()
        {
            var birdTypeList = _birdTypeService.GetAll();

            if (birdTypeList == null)
            {
                return NotFound("");
            }
            return birdTypeList;
        }
     
    }

}
