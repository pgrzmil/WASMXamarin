using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
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
        TextView resultView;
        TextView timeLabel;
        ProgressDialog progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PerformanceTest);
            Title = GetString(Resource.String.menuPerformance);

            digitsEntry = FindViewById<EditText>(Resource.Id.digitsEntry);
            resultView = FindViewById<TextView>(Resource.Id.resultView);
            timeLabel = FindViewById<TextView>(Resource.Id.timeLabel);
            startButton = FindViewById<Button>(Resource.Id.startButton);

            startButton.Click += StartCalculation;
            PerformanceTestService.Instance.PiCalculationCompleted += PiCalculationCompleted;
        }

        private void StartCalculation(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            progressDialog = ProgressDialog.Show(this, "Przetwarzanie...", "");

            var digits = Convert.ToInt32(digitsEntry.Text);
            new Thread(new Runnable(() =>
            {
                PerformanceTestService.Instance.CalculatePi(digits);
            })).Start();
        }

        private void PiCalculationCompleted(string result)
        {
            stopwatch.Stop();
            RunOnUiThread(new Runnable(() =>
            {
                resultView.Text = result;
                timeLabel.Text = stopwatch.GetDurationInSeconds();
                progressDialog.Dismiss();
            }));
        }
    }
}