using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("Add")]
        public IActionResult Add(Role role)
        {
            var r = _roleService.Add(role);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpPut("Update")]
        public IActionResult Update(Role role)
        {
            var r = _roleService.Update(role);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(Role role)
        {
            var r = _roleService.Delete(role);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var r = _roleService.GetAllRoles();
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("GetRoleById")]
        public IActionResult GetRoleById(int id)
        {
            var r = _roleService.GetRoleById(id);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }


    }
}
