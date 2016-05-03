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

        public NetworkTestController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AddressField.Text = "http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";
            NetworkDownloadService.Instance.ImageDownloadCompleted += Instance_DownloadCompleted;
        }

        partial void StartDownloading(UIButton sender)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);

            stopwatch.Start();
            NetworkDownloadService.Instance.DownloadImage(AddressField.Text);
        }

        private void Instance_DownloadCompleted(NSData data)
        {
            stopwatch.Stop();
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                DownloadedImage.Image = UIImage.LoadFromData(data);
                RefreshUI(false);
                TimeLabel.Text = String.Format("Czas wykonania: {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 4));
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