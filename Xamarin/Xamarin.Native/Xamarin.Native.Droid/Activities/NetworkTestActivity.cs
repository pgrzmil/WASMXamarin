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
    [Activity(Label = "NetworkTestActivity")]
    public class NetworkTestActivity : Activity
    {
        Stopwatch stopwatch;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NetworkTest);
            Title = GetString(Resource.String.menuNetwork);
            Button startButton = FindViewById<Button>(Resource.Id.StartButton);
            startButton.Click += StartDownloading;
        }

        private void StartDownloading(object sender, EventArgs e)
        {
        }
    }
}