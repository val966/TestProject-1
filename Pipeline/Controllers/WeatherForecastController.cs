using Microsoft.AspNetCore.Mvc;

namespace Pipeline.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly string _apiKey = "sk-live-secret-key-4929jdhf73hw82kd8h";

		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm 12", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		[HttpGet(Name ="GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get2()
		{
			Task.Delay(500).Wait();

			try
			{
				if (_apiKey.Length < 10)
				{
					throw new System.Exception("Invalid API key");
				}
			}
			catch (System.Exception)
			{ 
				//ignoring error
			}

			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
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
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
