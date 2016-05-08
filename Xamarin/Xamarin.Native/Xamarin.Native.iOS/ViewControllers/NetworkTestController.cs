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
            AddressField.Text = "http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";
            networkService = new NetworkTestService();
            networkService.ImageDownloadCompleted += ImageDownloadCompleted;
        }

        partial void StartDownloading(UIButton sender)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            RefreshUI(true);

            DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
            {
                networkService.DownloadImage(AddressField.Text);
            });
        }

        private void ImageDownloadCompleted(UIImage image)
        {
            stopwatch.Stop();
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                DownloadedImage.Image = image;
                TimeLabel.Text = stopwatch.GetDurationInSeconds();
                RefreshUI(false);
            });
        }

        private void RefreshUI(bool isDownloading)
        {
            StartButton.Hidden = isDownloading;
            AddressField.Enabled = isDownloading;
            ActivityIndicator.Hidden = !isDownloading;
            ActivityIndicator.StartAnimating();
        }
    }
}