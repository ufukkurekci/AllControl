using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService appUserRoleService)
        {
            _userRoleService = appUserRoleService;
        }
        [HttpPost("Add")]
        public IActionResult Add(UserRole appUserRole)
        {
            var r = _userRoleService.Add(appUserRole);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserRole appUserRole)
        {
            var r = _userRoleService.Update(appUserRole);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(UserRole appUserRole)
        {
            var r = _userRoleService.Delete(appUserRole);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("GetUserRoleByUserId")]
        public IActionResult GetUserRoleByUserId(int userid)
        {
            var r = _userRoleService.GetUserRoleByUserId(userid);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("GetAllUserRole")]
        public IActionResult GetAllUserRole()
        {
            var r = _userRoleService.GetAllUserRole();
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
    }
}
