using CoreFoundation;
using Foundation;
using System;
using System.Diagnostics;
using UIKit;
using Xamarin.Forms;

namespace Xamarin.iOS.ViewControllers
{
    public partial class NetworkTestController : UIViewController
    {
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
            Xamarin.Forms.Forms.Init();
            Title = "Test obs³ugi sieci";
            StartButton.TouchUpInside += StartDownloading;
            //http://i2.kym-cdn.com/photos/images/original/000/581/296/c09.jpg
            AdressField.Text = "http://cdn.superbwallpapers.com/wallpapers/meme/doge-pattern-27481-2880x1800.jpg";
        }

        bool isWorking = true;

        private void StartDownloading(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ActivityIndicator.Hidden = false;
            TimeLabel.Hidden = false;
            StartButton.Hidden = true;
            AdressField.UserInteractionEnabled = false;

            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                TimeLabel.Text = String.Format("{0}:{1}:{2}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
                return isWorking;
            });

            var url = NSUrl.FromString(AdressField.Text);
            DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
            {
                var data = NSData.FromUrl(url);
                DispatchQueue.MainQueue.DispatchAsync(() =>
                {
                    Picture.Image = UIImage.LoadFromData(data);
                    ActivityIndicator.Hidden = true;
                    StartButton.Hidden = false;
                    AdressField.UserInteractionEnabled = true;
                    isWorking = false;
                });
            });
        }
    }
}