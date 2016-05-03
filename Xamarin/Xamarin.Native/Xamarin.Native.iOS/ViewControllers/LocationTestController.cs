using CoreFoundation;
using Foundation;
using System;
using System.Diagnostics;
using System.Drawing;
using UIKit;
using Xamarin.iOS;

namespace Xamarin.Native.iOS.ViewControllers
{
    public partial class LocationTestController : UIViewController
    {
        Stopwatch stopwatch;
        LocationTestService locationService;

        public LocationTestController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            locationService = new LocationTestService();
            locationService.LocationChanged += LocationService_LocationChanged;
        }

        partial void StartPositioning(UIButton sender)
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
                // UIAlertView. DisplayAlert("B³¹d", "Lokalizacja niedostêpna", null);
            }
        }

        private void LocationService_LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                RefreshUI(false);
                PositionLabel.Text = string.Format("D³ugoœæ: {0}\nSzerokoœæ: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                TimeLabel.Text = string.Format("Czas wykonania: {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 4));
            });
        }

        private void RefreshUI(bool isDownloading)
        {
            StartButton.Hidden = isDownloading;
            ActivityIndicator.Hidden = !isDownloading;
            ActivityIndicator.StartAnimating();
        }
    }
}