using Microsoft.AspNetCore.Mvc;
using SvinefarmAPI.Interfaces;
using SvinefarmAPI.Model;
using SvinefarmAPI.Repository;

namespace SvinefarmAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : Controller
    {
        private readonly ITemperature _temperature;

        public TemperatureController(ITemperature temperature)
        {
            _temperature = temperature;
        }
        TemperatureRepository temperatureRepository = new TemperatureRepository();

        //[HttpGet("GetCurrentTemperature")]
        //public IActionResult GetCurrentTemperature() 
        //{
        //    return Ok(temperatureRepository.GetCurrentTemperature());
        //}

    }
}
