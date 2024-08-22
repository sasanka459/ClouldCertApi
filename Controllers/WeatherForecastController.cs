using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace qansapi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly AuthorizationManager authorizationManager;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(AuthorizationManager authorizationManager)
        {
            this.authorizationManager = authorizationManager;
        }




        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet(Name = "GetHello")]
        public string GetHello()
        {
            return "Hello world api";
        }

        [HttpPost(Name = "GetToken")]
        [AllowAnonymous]
        public IActionResult GetToken([FromBody] User user)
        {
            var key = authorizationManager.Authincate(user.UserName, user.Password);
            if (user.UserName == null && user.Password == null)
                return BadRequest();
            else
                return Ok(key);
        }

        public class User
        {
            public String UserName { get; set; }
            public String Password { get; set; }
        }
    }
}
