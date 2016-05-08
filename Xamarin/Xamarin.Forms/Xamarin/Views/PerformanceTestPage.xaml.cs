using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Helpers;
using Xamarin.Forms.Services;

namespace Xamarin.Views
{
    public partial class PerformanceTestPage : ContentPage
    {
        Stopwatch stopwatch;

        public PerformanceTestPage()
        {
            InitializeComponent();
            Title = "Test obliczeń";
            PerformanceTestService.Instance.PiCalculationCompleted += Instance_CalculationCompleted;
        }

        private void StartCalculation(object sender, EventArgs e)
        {
            resultView.Text = "";
            RefreshUI(true);

            stopwatch = new Stopwatch();
            stopwatch.Start();

            var digits = Convert.ToInt32(digitsEntry.Text);
            Task.Run(() => { PerformanceTestService.Instance.CalculatePi(digits); });
        }

        private void Instance_CalculationCompleted(string result)
        {
            stopwatch.Stop();
            Device.BeginInvokeOnMainThread(() =>
            {
                resultView.Text = result;
                timeLabel.Text = stopwatch.GetDurationInSeconds();
                RefreshUI(false);
            });
        }

        private void RefreshUI(bool isCalculating)
        {
            startButton.IsVisible = !isCalculating;
            digitsEntry.IsEnabled = !isCalculating;
            activityIndicator.IsVisible = isCalculating;
            activityIndicator.IsRunning = isCalculating;
        }
    }
}