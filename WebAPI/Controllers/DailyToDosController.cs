using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyToDosController : ControllerBase
    {
        IDailyToDoService _dailyToDoService;

        public DailyToDosController(IDailyToDoService dailyToDoService)
        {
            _dailyToDoService = dailyToDoService;
        }

        [HttpGet("GetDailyResultById")]
        public IActionResult GetDailyResultById(int todoid)
        {
            var r = _dailyToDoService.GetDailyResultById(todoid);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("GetAllDailyResult")]
        public IActionResult GetAllDailyResult()
        {
            var r = _dailyToDoService.GetAllDailyResult();
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpPost("Add")]
        public IActionResult Add(DailyToDo dailyToDo)
        {
            var r = _dailyToDoService.Add(dailyToDo);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpPut("Update")]
        public IActionResult Update(DailyToDo dailyToDo)
        {
            var r = _dailyToDoService.Update(dailyToDo);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(DailyToDo dailyToDo)
        {
            var r = _dailyToDoService.Delete(dailyToDo);
            if (r.IsSuccess)
            {
                return Ok(r);
            }
            return BadRequest(r.Message);
        }



    }
}
