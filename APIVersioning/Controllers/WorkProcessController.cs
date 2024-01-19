using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioning.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/{v:apiVersion}/[controller]")]
    public class WorkProcessController : ControllerBase
    {
        [HttpGet(Name = "GetProcessById")]
        public IActionResult GetProcessById(int Id)
        {
            if (Id == 0)
                return BadRequest($"Process Id should not be {Id}");

            return Ok(Id);
        }

        [ApiVersion("2.0")]
        [HttpOptions(Name = "GetProcessByName")]
        public IActionResult GetProcessByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Process Name should not be null/empty");

            return Ok(name);
        }
    }
}
