using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin.Views
{
    public partial class PerformanceTestPage : ContentPage
    {
        public PerformanceTestPage()
        {
            InitializeComponent();
            Title = "Test obliczeń".ToUpper();
            PerformanceTestService.Instance.PiCalculationCompleted += Instance_CalculationCompleted;
        }

        Stopwatch stopwatch;

        private void StartCalculation(object sender, EventArgs e)
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
            Device.BeginInvokeOnMainThread(() =>
            {
                ResultView.Text = result;
                RefreshUI(false);

                TimeLabel.Text = String.Format("Czas wykonania: {0}:{1}:{2}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            });
        }

        private void RefreshUI(bool isCalculating)
        {
            StartButton.IsVisible = !isCalculating;
            DigitsEntry.IsEnabled = !isCalculating;
            ActivityIndicator.IsVisible = isCalculating;
            ActivityIndicator.IsRunning = isCalculating;
        }
    }
}