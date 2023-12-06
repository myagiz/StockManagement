using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IStockTypeService _stockTypeService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStockTypeService stockTypeService)
        {
            _logger = logger;
            _stockTypeService = stockTypeService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("AddStockType")]
        public IActionResult AddStockType(StockType model)
        {
            var result = _stockTypeService.AddStockType(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}