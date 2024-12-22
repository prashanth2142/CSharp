using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        //public IEnumerable<string> Post()
        //{
        //    try
        //    {
        //        Console.WriteLine("Post Method Executed");

        //        // Simulating an exception
        //        string s = "QWWWERRE";
        //        s = null; // This will cause a NullReferenceException
        //        Console.WriteLine(s.ToLower()); // This line throws the exception
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception if necessary
        //        Console.WriteLine($"Exception caught: {ex.Message}");

        //        // Rethrow the exception so that the global exception handler can catch it
        //        throw;
        //    }

        //    return new[] { "A", "B" }; // This won't be reached due to the exception
        //}

        [HttpPost]
        public IEnumerable<string> Post()
        {
            Console.WriteLine("Post Method Executed");

            // Simulating an exception
            string s = "QWWWERRE";
            s = null; // This will cause a NullReferenceException
            Console.WriteLine(s.ToLower()); // This line throws the exception

            return new[] { "A", "B" }; // This won't be reached due to the exception
        }


    }
}