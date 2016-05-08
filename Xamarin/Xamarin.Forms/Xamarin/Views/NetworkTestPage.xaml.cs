using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Helpers;
using Xamarin.Forms.Services;

namespace Xamarin.Views
{
    public partial class NetworkTestPage : ContentPage
    {
        Stopwatch stopwatch;
        NetworkDownloadService networkService;

        public NetworkTestPage()
        {
            InitializeComponent();
            Title = "Test obsługi sieci";
            addressField.Text = "http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";

            networkService = new NetworkDownloadService();
            networkService.ImageDownloadCompleted += Instance_DownloadCompleted;
        }

        private void StartDownloading(object sender, EventArgs e)
        {
            downloadedImage.Source = null;
            RefreshUI(true);

            stopwatch = new Stopwatch();
            stopwatch.Start();

            networkService.DownloadImage(addressField.Text);
        }

        private void Instance_DownloadCompleted(ImageSource image)
        {
            stopwatch.Stop();
            Device.BeginInvokeOnMainThread(() =>
            {
                downloadedImage.Source = image;
                timeLabel.Text = stopwatch.GetDurationInSeconds();
                RefreshUI(false);
            });
        }

        private void RefreshUI(bool isDownloading)
        {
            startButton.IsVisible = !isDownloading;
            addressField.IsEnabled = !isDownloading;
            activityIndicator.IsVisible = isDownloading;
            activityIndicator.IsRunning = isDownloading;
        }
    }
}