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

        private void LocationService_LocationFailed()
        {
            RunOnUiThread(() =>
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("B³¹d");
                builder.SetMessage("Lokalizacja niedostêpna");
                builder.SetCancelable(false);
                builder.SetPositiveButton("OK", delegate { Finish(); });
                builder.Show();
            });
        }

        private void StartPositioning(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            RefreshUI(true);

            stopwatch.Start();
            locationService.GetLocation();
        }

        private void LocationService_LocationChanged(double latitude, double longitude)
        {
            stopwatch.Stop();
            RunOnUiThread(() =>
            {
                RefreshUI(false);
                PositionLabel.Text = string.Format("D³ugoœæ: {0}\nSzerokoœæ: {1}", Math.Round(longitude, 4), Math.Round(latitude, 4));
                TimeLabel.Text = string.Format("Czas wykonania: {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 4));
            });
        }

        private void RefreshUI(bool isPositioning)
        {
            if (isPositioning)
            {
                startButton.Visibility = ViewStates.Invisible;
                progressDialog = ProgressDialog.Show(this, "Wyznaczanie pozycji...", "");
            }
            else
            {
                startButton.Visibility = ViewStates.Visible;
                progressDialog.Dismiss();
            }
        }
    }
}