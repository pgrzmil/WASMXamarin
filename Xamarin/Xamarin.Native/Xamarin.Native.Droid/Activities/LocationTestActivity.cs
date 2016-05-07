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
using Xamarin.iOS;

namespace Xamarin.Native.Droid.Activities
{
    [Activity(Label = "LocationActivity")]
    public class LocationTestActivity : Activity
    {
        Stopwatch stopwatch;
        LocationTestService locationService;
        Button startButton;
        TextView TimeLabel;
        TextView PositionLabel;
        ProgressDialog progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LocationTest);
            Title = GetString(Resource.String.menuLocation);

            locationService = new LocationTestService();
            locationService.LocationChanged += LocationService_LocationChanged;

            TimeLabel = FindViewById<TextView>(Resource.Id.TimeLabel);
            PositionLabel = FindViewById<TextView>(Resource.Id.PositionLabel);
            startButton = FindViewById<Button>(Resource.Id.StartButton);
            startButton.Click += StartPositioning;
        }

        private void StartPositioning(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            progressDialog = ProgressDialog.Show(this, "Wyznaczanie pozycji...", "");

            stopwatch.Start();
            locationService.GetLocation();
        }

        private void LocationService_LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            RunOnUiThread(() =>
            {
                PositionLabel.Text = string.Format("D³ugoœæ: {0}\nSzerokoœæ: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                TimeLabel.Text = stopwatch.GetDurationInSeconds();
                progressDialog.Dismiss();
            });
        }
    }
}