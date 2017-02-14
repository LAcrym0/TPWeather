using Xamarin.Forms;
using System;

namespace TPWeather
{
	public partial class TPWeatherPage : ContentPage
	{
		public TPWeatherPage()
		{
			InitializeComponent();
			searchButton.Clicked += searchWeatherForCity;
		}

		private async void searchWeatherForCity(object sender, EventArgs eventArgs)
		{
			System.Diagnostics.Debug.WriteLine("OK here");
			if (!String.IsNullOrEmpty(cityEntry.Text))
			{
				Weather weather = await Utils.GetWeather(cityEntry.Text);
				if (weather != null)
				{
					System.Diagnostics.Debug.WriteLine("Weather OK");
					resultLayout.IsVisible = true;
					this.BindingContext = weather;
				}
				else {
					System.Diagnostics.Debug.WriteLine("Weather KO");
				}
			}
		}
	}
}
