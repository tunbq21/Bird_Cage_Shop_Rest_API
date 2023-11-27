using BirdCageShop.BusinessLogic.BusinessModel.RequestModels.User;
using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/register")]
    public class RegisterController : ControllerBase
    {
        private IRegisterService _registerService;
        private IConfiguration _configuration;
        public RegisterController(IRegisterService regisService)
        {
            _registerService = regisService;

        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<RegisterViewModel> Register(RegisterRequestModel registerRequest)
        {
            var register = _registerService.Register(registerRequest);
            if (register == false) return BadRequest();

            return Ok();

        }
    }
}
