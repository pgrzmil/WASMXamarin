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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            locationService = new LocationTestService();
            locationService.LocationChanged += LocationChanged;
        }

        partial void StartPositioning(UIButton sender)
        {
            RefreshUI(true);

            stopwatch = new Stopwatch();
            stopwatch.Start();

            locationService.GetLocation();
        }

        private void LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                positionLabel.Text = string.Format("Długość: {0}\nSzerokość: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                timeLabel.Text = string.Format("{0}\n{1}", stopwatch.GetDurationInSeconds(), stopwatch.GetDurationInMilliseconds());
                RefreshUI(false);
            });
        }

        private void RefreshUI(bool isPositioning)
        {
            startButton.Hidden = isPositioning;
            activityIndicator.Hidden = !isPositioning;
        }
    }
}