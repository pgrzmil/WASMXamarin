using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Helpers;
using Xamarin.Forms.Services;

namespace Xamarin.Views
{
    public partial class LocationTestPage : ContentPage
    {
        Stopwatch stopwatch;
        LocationTestService locationService;

        public LocationTestPage()
        {
            InitializeComponent();
            Title = "Test pozycji GPS";
            locationService = new LocationTestService();
            locationService.LocationChanged += LocationChanged;
        }

        private void StartPositioning(object sender, EventArgs e)
        {
            RefreshUI(true);

            stopwatch = new Stopwatch();
            stopwatch.Start();

            locationService.GetLocation();
        }

        private void LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            Device.BeginInvokeOnMainThread(() =>
            {
                positionLabel.Text = string.Format("Długość: {0}\nSzerokość: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                timeLabel.Text = string.Format("{0}\n{1}", stopwatch.GetDurationInSeconds(), stopwatch.GetDurationInMilliseconds());
                RefreshUI(false);
            });
        }

        private void RefreshUI(bool isDownloading)
        {
            startButton.IsVisible = !isDownloading;
            activityIndicator.IsVisible = isDownloading;
            activityIndicator.IsRunning = isDownloading;
        }
    }
}