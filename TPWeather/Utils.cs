using System;
using System.Threading.Tasks;

namespace TPWeather
{
	public class Utils
	{
		public static async Task<Weather> GetWeather(string zipCode)
		{
			string key = "b745637bc806cfc4be117e26aa12fc90";
			string apiUrl = "http://samples.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&appid=" + key;

			dynamic results = await WeatherTreatment.getWeather(apiUrl).ConfigureAwait(false);

			if (results["weather"] != null)
			{
				Weather weather = new Weather();
				weather.Temperature = (string)results["main"]["temp"] + "°F";
				weather.Title = (string)results["name"];
				weather.Visibility = (string)results["weather"][0]["main"];
				weather.Wind = (string)results["wind"]["speed"] + " mph";
				weather.Humidity = (string)results["main"]["humidity"] + " %";

				DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
				DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
				DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
				weather.Sunrise = sunrise.ToString();
				weather.Sunset = sunset.ToString();
				return weather;
			}
			else
			{
				return null;
			}
		}
	}
}
