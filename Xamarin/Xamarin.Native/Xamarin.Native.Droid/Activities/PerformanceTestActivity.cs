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

namespace Xamarin.Native.Droid.Activities
{
    [Activity(Label = "PerformanceActivity")]
    public class PerformanceTestActivity : Activity
    {
        Stopwatch stopwatch;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PerformanceTest);
            Title = GetString(Resource.String.menuPerformance);

            Button startButton = FindViewById<Button>(Resource.Id.StartButton);
            startButton.Click += StartCalculation;
        }

        private void StartCalculation(object sender, EventArgs e)
        {
        }
    }
}