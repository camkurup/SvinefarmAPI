using Microsoft.AspNetCore.Mvc;
using SvinefarmAPI.Data;

namespace SvinefarmAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LightLogController : Controller
    {
        DataAccess databaseAccess = new DataAccess();

        [HttpGet("GetLevelOfLight")]
        public IActionResult GetCurrentTemperature()
        {
            return Ok(databaseAccess.GetLevelOfLight());
        }
    }
}
