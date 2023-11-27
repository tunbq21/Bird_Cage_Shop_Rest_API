

using BirdCageShop.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Role;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace BirdCageShop.Presentation.Controllers 
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/roles")]
    public class RoleController : ControllerBase {

        private IRoleService _roleService;

         public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<RoleViewModel> CreateRole(CreateRoleRequestModel roleCreate)
        {
            var roleCreated = _roleService.CreateRole(roleCreate);

            if (roleCreated == null)
            {
                return NotFound("");
            }
            return roleCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<RoleViewModel>> GetAll()
        {
            var roleList = _roleService.GetAll();

            if (roleList == null)
            {
                return NotFound("");
            }
            return roleList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<RoleViewModel> GetById(int idTmp)
        {
            var roleDetail = _roleService.GetById(idTmp);

            if (roleDetail == null)
            {
                return NotFound("");
            }
            return roleDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteRole(int idTmp)
        {
            var check = _roleService.DeleteRole(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<RoleViewModel> UpdateRole(UpdateRoleRequestModel roleCreate)
        {
            var roleUpdated = _roleService.UpdateRole(roleCreate);

            if (roleUpdated == null)
            {
                return NotFound("");
            }
            return roleUpdated;
        }
    }

}
