     
using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/users")]
    public class UserController : ControllerBase {

        private IUserService _userService;

         public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<UserViewModel> CreateUser(CreateUserRequestModel userCreate)
        {
            var userCreated = _userService.CreateUser(userCreate);

            if (userCreated == null)
            {
                return NotFound("");
            }
            return userCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<UserViewModel>> GetAll()
        {
            var userList = _userService.GetAll();

            if (userList == null)
            {
                return NotFound("");
            }
            return userList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<UserViewModel> GetById(string idTmp)
        {
            var userDetail = _userService.GetById(idTmp);

            if (userDetail == null)
            {
                return NotFound("");
            }
            return userDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteUser(string idTmp)
        {
            var check = _userService.DeleteUser(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }
        [MapToApiVersion("1")]
        [HttpDelete("userid")]
        public ActionResult<bool> RemoveUser(string userid)
        {
            var check = _userService.RemoveUser(userid);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<UserViewModel> UpdateUser(UpdateUserRequestModel userCreate)
        {
            var userUpdated = _userService.UpdateUser(userCreate);

            if (userUpdated == null)
            {
                return NotFound("");
            }
            return userUpdated;
        }
    }

}
