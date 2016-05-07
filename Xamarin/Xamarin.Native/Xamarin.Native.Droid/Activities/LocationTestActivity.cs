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
using Xamarin.iOS;
using Math = System.Math;

namespace Xamarin.Native.Droid.Activities
{
    [Activity(Label = "LocationActivity")]
    public class LocationTestActivity : Activity
    {
        Stopwatch stopwatch;
        LocationTestService locationService;
        Button startButton;
        TextView timeLabel;
        TextView positionLabel;
        ProgressDialog progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LocationTest);
            Title = GetString(Resource.String.menuLocation);

            timeLabel = FindViewById<TextView>(Resource.Id.timeLabel);
            positionLabel = FindViewById<TextView>(Resource.Id.positionLabel);
            startButton = FindViewById<Button>(Resource.Id.startButton);

            startButton.Click += StartPositioning;
            locationService = new LocationTestService(this);
            locationService.LocationChanged += LocationService_LocationChanged;
        }

        private void StartPositioning(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            progressDialog = ProgressDialog.Show(this, "Wyznaczanie pozycji...", "");

            locationService.GetLocation();
        }

        private void LocationService_LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            RunOnUiThread(new Runnable(() =>
            {
                positionLabel.Text = string.Format("D³ugoœæ: {0}\nSzerokoœæ: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                timeLabel.Text = stopwatch.GetDurationInSeconds();
                progressDialog.Dismiss();
            }));
        }
    }
}