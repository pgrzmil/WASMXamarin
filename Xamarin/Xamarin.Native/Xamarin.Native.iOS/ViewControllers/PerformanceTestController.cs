using CoreFoundation;
using Foundation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Services;

namespace Xamarin.Native.iOS.ViewControllers
{
    public partial class PerformanceTestController : UIViewController
    {
        Stopwatch stopwatch;

        public PerformanceTestController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            PerformanceTestService.Instance.PiCalculationCompleted += Instance_CalculationCompleted;
        }

        partial void StartCalculation(UIButton sender)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);

            var digits = Convert.ToInt32(DigitsEntry.Text);
            Task.Run(() =>
            {
                stopwatch.Start();
                PerformanceTestService.Instance.CalculatePi(digits);
            });
        }

        private void Instance_CalculationCompleted(string result)
        {
            stopwatch.Stop();

            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                ResultView.Text = result;
                RefreshUI(false);

                TimeLabel.Text = stopwatch.GetDurationInSeconds();
            });
        }

        private void RefreshUI(bool isCalculating)
        {
            StartButton.Hidden = isCalculating;
            DigitsEntry.Enabled = isCalculating;
            ActivityIndicator.Hidden = !isCalculating;
            ActivityIndicator.StartAnimating();
        }
    }
}