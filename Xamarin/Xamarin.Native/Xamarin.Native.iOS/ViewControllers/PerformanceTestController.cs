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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            PerformanceTestService.Instance.PiCalculationCompleted += PiCalculationCompleted;
        }

  		partial void StartCalculation (UIButton sender)
		{
			resultView.Text = @"";
			RefreshUI(true);
			stopwatch = new Stopwatch();
			stopwatch.Start();

			var digits = Convert.ToInt32(digitsEntry.Text);
			DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
			{
				PerformanceTestService.Instance.CalculatePi(digits);
			});
		}

		private void PiCalculationCompleted(string result)
		{
			stopwatch.Stop();

			DispatchQueue.MainQueue.DispatchAsync(() =>
			{
				resultView.Text = result;
				timeLabel.Text = stopwatch.GetDurationInSeconds();
				RefreshUI(false);
			});
		}

		private void RefreshUI(bool isCalculating)
		{
			startButton.Hidden = isCalculating;
			digitsEntry.Enabled = isCalculating;
			activityIndicator.Hidden = !isCalculating;
		}


    }
}