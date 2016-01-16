using Foundation;
using System;
using System.Diagnostics;
using UIKit;
using Xamarin.Forms;

namespace WASMXamarin.iOS.ViewControllers
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
            Title = "Test obs³ugi sieci";
            StartButton.TouchUpInside += StartDownloading;
            NetworkDownloadService.Instance.DownloadCompleted += Instance_DownloadCompleted;
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

            NetworkDownloadService.Instance.DownloadImage(AdressField.Text);
        }

        private void Instance_DownloadCompleted(byte[] bytes)
        {
            if (bytes == null)
                new UIAlertView("B³¹d", "Pobieranie nie powiod³o siê.", null, "OK", null).Show();

            try
            {
                var image = new UIImage(NSData.FromArray(bytes));
                Picture.Image = image;
            }
            catch (Exception)
            {
                new UIAlertView("B³¹d", "Pobieranie nie powiod³o siê.", null, "OK", null).Show();
            }
            finally
            {
                ActivityIndicator.Hidden = true;
                StartButton.Hidden = false;
                AdressField.UserInteractionEnabled = true;
                isWorking = false;
            }
        }
    }
}