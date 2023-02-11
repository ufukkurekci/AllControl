using Business.Abstract;
using Core.Entites;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        IToDoService _todoService;
        private static IHttpContextAccessor _httpContextAccessor;

        public ToDosController(IToDoService todoService , IHttpContextAccessor httpContextAccessor )
        {
            _todoService = todoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("Getalltodo")]
        public IActionResult Get()
        {
            var result = _todoService.GetAllToDo();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("Getbyid")]
        public IActionResult GetById(int id)
        {
            var r = _todoService.GetById(id);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r);
        }
        [HttpPost("Addtodo")]
        public  IActionResult Post(ToDo toDo)
        {
            var r =  _todoService.Add(toDo);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r);

        }
        [HttpPut("Updatetodo")]
        public IActionResult Update(ToDo toDo)
        {
            var r = _todoService.Update(toDo);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r);
        }
        [HttpGet]
        public IActionResult Delete(ToDo toDo)
        {
            var r = _todoService.Delete(toDo);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r);
        }

    }
}
