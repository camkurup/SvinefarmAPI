using Microsoft.AspNetCore.Mvc;
using SvinefarmAPI.Data;

namespace SvinefarmAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : Controller
    {
        TemperatureRepository temperatureRepository = new TemperatureRepository();

        [HttpGet("GetCurrentTemperature")]
        public IActionResult GetCurrentTemperature() 
        {
            return Ok(temperatureRepository.GetCurrentTemperature());
        }
    }
}
