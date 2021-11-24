using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrintPDF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace PrintPDF.Controllers
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
        readonly IGeneratePdf _generatePdf;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGeneratePdf generatePdf)
        {
            _logger = logger;
            _generatePdf = generatePdf;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = new Test
            {
                Text = "This is a test",
                Number = 123456
            };

            return await _generatePdf.GetPdf("Views/Test.cshtml", data);
        }
    }
}
