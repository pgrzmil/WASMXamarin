using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Services;

namespace Xamarin.Native.Droid.Activities
{
    [Activity(Label = "PerformanceActivity")]
    public class PerformanceTestActivity : Activity
    {
        Stopwatch stopwatch;
        Button startButton;
        EditText digitsEntry;
        TextView ResultView;
        TextView TimeLabel;
        ProgressDialog progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PerformanceTest);
            Title = GetString(Resource.String.menuPerformance);

            PerformanceTestService.Instance.PiCalculationCompleted += Instance_CalculationCompleted;

            digitsEntry = FindViewById<EditText>(Resource.Id.DigitsEntry);
            ResultView = FindViewById<TextView>(Resource.Id.ResultView);
            TimeLabel = FindViewById<TextView>(Resource.Id.TimeLabel);
            startButton = FindViewById<Button>(Resource.Id.StartButton);

            startButton.Click += StartCalculation;
        }

        private void StartCalculation(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);

            var digits = Convert.ToInt32(digitsEntry.Text);
            Task.Run(() =>
            {
                stopwatch.Start();
                PerformanceTestService.Instance.CalculatePi(digits);
            });
        }

        private void Instance_CalculationCompleted(string result)
        {
            stopwatch.Stop();
            RunOnUiThread(() =>
            {
                ResultView.Text = result;
                RefreshUI(false);
                TimeLabel.Text = String.Format("Czas wykonania: {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 4));
            });
        }

        private void RefreshUI(bool isCalculating)
        {
            digitsEntry.Enabled = !isCalculating;

            if (isCalculating)
            {
                startButton.Visibility = ViewStates.Invisible;
                progressDialog = ProgressDialog.Show(this, "Przetwarzanie...", "");
            }
            else
            {
                startButton.Visibility = ViewStates.Visible;
                progressDialog.Dismiss();
            }
        }
    }
}