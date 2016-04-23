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
using Xamarin;

namespace Xamarin.Droid
{
    [Activity(Label = "PerformanceActivity")]
    public class PerformanceActivity : Activity
    {
        Button startBtn;
        EditText digitsText;
        TextView timeText;
        TextView resultText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_performance);

            digitsText = FindViewById<EditText>(Resource.Id.digitsText);
            timeText = FindViewById<TextView>(Resource.Id.timeText);
            resultText = FindViewById<TextView>(Resource.Id.resultText);
            startBtn = FindViewById<Button>(Resource.Id.startBtn);

            startBtn.Click += (sender, e) =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int digits = int.Parse(digitsText.Text);
                String result = PerformanceTestService.CalculatePi(digits);
                stopwatch.Stop();

                long stopTime = stopwatch.ElapsedMilliseconds;
                resultText.Text = result;
                timeText.Text = String.Format("{0}:{1}:{2}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            };
        }
    }
}