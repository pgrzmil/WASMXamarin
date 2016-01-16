using System;
using System.Threading;
using System.Diagnostics;
using UIKit;
using Xamarin.Forms;

namespace WASMXamarin.iOS.ViewControllers
{
    public partial class PerformanceTestController : UIViewController
    {
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
            StartButton.TouchUpInside += StartCalculation;
            DigitsTextfield.Text = "10000";
            Title = "Test wydajnoœci obliczeñ";
        }

        private void StartCalculation(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            activityIndicator.Hidden = false;
            TimeLabel.Hidden = false;
            StartButton.Hidden = true;
            DigitsTextfield.UserInteractionEnabled = false;

            var digits = Convert.ToInt32(DigitsTextfield.Text);
            bool isCalculating = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                TimeLabel.Text = String.Format("{0}:{1}:{2}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
                return isCalculating;
            });

            ThreadPool.QueueUserWorkItem(new WaitCallback((x) =>
            {
                var pi = PerformanceTestService.CalculatePi(digits);
                Device.BeginInvokeOnMainThread(() =>
                {
                    ResultView.Text = pi;
                    isCalculating = false;
                    activityIndicator.Hidden = true;
                    StartButton.Hidden = false;
                    DigitsTextfield.UserInteractionEnabled = true;
                    stopwatch.Stop();
                });
            }));
        }
    }
}