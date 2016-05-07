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
                DispatchQueue.MainQueue.DispatchAsync(() =>
                {
                    UIAlertView alert = new UIAlertView() { Title = "B³¹d", Message = "Lokalizacja niedostêpna" };
                    alert.AddButton("OK");
                    alert.Show();
                });
            }
        }

        private void LocationService_LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                RefreshUI(false);
                PositionLabel.Text = string.Format("D³ugoœæ: {0}\nSzerokoœæ: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                TimeLabel.Text = stopwatch.GetDurationInSeconds();
            });
        }

        private void RefreshUI(bool isPositioning)
        {
            StartButton.Hidden = isPositioning;
            ActivityIndicator.Hidden = !isPositioning;
            ActivityIndicator.StartAnimating();
        }
    }
}