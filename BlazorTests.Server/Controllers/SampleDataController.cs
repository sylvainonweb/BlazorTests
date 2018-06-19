using BlazorTests.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            IList<WeatherForecast> forecasts = new List<WeatherForecast>();

            for(int i = 0; i<1000; i++)
            {
                forecasts.Add(new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = i,
                    Summary = "Summary " + i
                });
            }

            return forecasts;
        }
    }
}
