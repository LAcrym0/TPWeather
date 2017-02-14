using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace TPWeather
{
	public class WeatherTreatment
	{
		public static async Task<dynamic> getWeather(string weatherRequest)
		{
			HttpClient httpClient = new HttpClient();
			var response = await httpClient.GetAsync(weatherRequest);

			dynamic responseData = null;
			if (response != null)
			{
				string json = response.Content.ReadAsStringAsync().Result;
				responseData = JsonConvert.DeserializeObject(json);
				System.Diagnostics.Debug.WriteLine("CALL SUCCEEDED");
				System.Diagnostics.Debug.WriteLine(json);
			}
			System.Diagnostics.Debug.WriteLine("CALL DONE");
			return responseData;
		}
	}
}
