using CoreFoundation;
using Foundation;
using System;
using System.Diagnostics;
using System.Drawing;
using UIKit;
using Xamarin.Services;

namespace Xamarin.Native.iOS.ViewControllers
{
    public partial class NetworkTestController : UIViewController
    {
        Stopwatch stopwatch;
        NetworkTestService networkService;

        public NetworkTestController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            addressField.Text = "http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";
            
			networkService = new NetworkTestService();
            networkService.ImageDownloadCompleted += ImageDownloadCompleted;
        }

        partial void StartDownloading (UIButton sender)
		{
			downloadedImage.Image = null;
			RefreshUI(true);
			stopwatch = new Stopwatch();
			stopwatch.Start();

			string url = addressField.Text;
			DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
			{
				networkService.DownloadImage(url);
			});
		}

		private void ImageDownloadCompleted(UIImage image)
		{
			stopwatch.Stop();
			DispatchQueue.MainQueue.DispatchAsync(() =>
			{
				downloadedImage.Image = image;
				timeLabel.Text = stopwatch.GetDurationInSeconds();
				RefreshUI(false);
			});
		}

		private void RefreshUI(bool isDownloading)
		{
			startButton.Hidden = isDownloading;
			addressField.Enabled = isDownloading;
			activityIndicator.Hidden = !isDownloading;
		}
    }
}