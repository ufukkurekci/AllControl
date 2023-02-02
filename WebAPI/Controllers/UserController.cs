using Business.Abstract;
using Core.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userservice;

        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }
        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            var r = _userservice.Add(user);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpPut("Update")]
        public IActionResult Update(User user)
        {
            var r = _userservice.Update(user);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(User user)
        {
            var r = _userservice.Delete(user);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int userid)
        {
            var r = _userservice.GetById(userid);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var r = _userservice.GetAllUser();
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
    }
}
