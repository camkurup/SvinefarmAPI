using Microsoft.AspNetCore.Mvc;
using SvinefarmAPI.Data;

namespace SvinefarmAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureLogController : Controller
    {
        DataAccess databaseAccess = new DataAccess();

        [HttpGet("GetCurrentTemperature")]
        public IActionResult GetCurrentTemperature() 
        {
            return Ok(databaseAccess.GetCurrentTemperature());
        }
    }
}
