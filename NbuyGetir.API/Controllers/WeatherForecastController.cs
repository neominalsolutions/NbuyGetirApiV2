using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbuyGetir.Core.Services;
using NBuyGetir.Domain.Services;
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

        private StockInService _stockInService;

       

        public WeatherForecastController(StockInService stockInService)
        {
            _stockInService = stockInService;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            await _stockInService.StockIn("1", 12);

            return Ok();
        }
    }
}
