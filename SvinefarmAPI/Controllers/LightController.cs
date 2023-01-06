using Microsoft.AspNetCore.Mvc;
using SvinefarmAPI.Repository;

namespace SvinefarmAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LightController : Controller
    {
        LightRepository lightRepository = new LightRepository();

        [HttpGet("GetLevelOfLight")]
        public IActionResult GetCurrentTemperature()
        {
            return Ok(lightRepository.GetLevelOfLight());
        }
    }
}
