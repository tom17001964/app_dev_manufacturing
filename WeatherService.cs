using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Manufacturing_Society_App.Extensions
{
    public class WeatherService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiKey = "b20269004f2bace3292ee21f8c49984b"; // Your OpenWeather API key

        public async Task<string> GetWeatherAsync(string city)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric";
            var response = await client.GetStringAsync(url);
            var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(response);
            return $"Current weather in {city}: {weatherData.Main.Temp}°C, {weatherData.Weather[0].Description}";
        }
    }

    public class WeatherResponse
    {
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
    }
}
