using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbuyGetir.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbuyGetir.API.Controllers
{
    public class ProductRequestDto
    {
        public string Name { get; set; }

    }

    public class ProductResponseDto
    {
        public bool Success { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private IApplicationService<ProductRequestDto, ProductResponseDto> service;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IActionResult Test()
        //{
        //    //var response =  service.HandleAsync(new ProductRequestDto());
        //    //return Ok(response);

        //    return Ok();
        //}

        // SOLID PRINCIPLES

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
