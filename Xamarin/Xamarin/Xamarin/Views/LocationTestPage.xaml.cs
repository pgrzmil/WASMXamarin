using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Services;

namespace Xamarin.Views
{
    public partial class GpsTestPage : ContentPage
    {
        Stopwatch stopwatch;
        ILocationTestService locationService;

        public GpsTestPage()
        {
            InitializeComponent();
            Title = "Test pozycji GPS".ToUpper();
            locationService = DependencyService.Get<ILocationTestService>();
            locationService.LocationChanged += LocationService_LocationChanged;
        }

        private void StartPositioning(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);

            stopwatch.Start();
            try
            {
                locationService.GetLocation();
            }
            catch (LocationUnavailableException)
            {
                DisplayAlert("Błąd", "Lokalizacja niedostępna", null);
            }
        }

        private void LocationService_LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            Device.BeginInvokeOnMainThread(() =>
            {
                RefreshUI(false);
                PositionLabel.Text = string.Format("Długość: {0}\nSzerokość: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                TimeLabel.Text = string.Format("Czas wykonania: {0}:{1}:{2}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            });
        }

        private void RefreshUI(bool isDownloading)
        {
            StartButton.IsVisible = !isDownloading;
            ActivityIndicator.IsVisible = isDownloading;
            ActivityIndicator.IsRunning = isDownloading;
        }
    }
}